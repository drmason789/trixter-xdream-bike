using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Trixter.XDream.API
{
    /// <summary>
    /// Uses the change in crank position over a sampling interval to determine speed (RPM) and direction of crank movement.
    /// </summary>
    [DebuggerDisplay("HasData: {HasData} RPM:{RPM}")]
    public class PositionalCrankMeter : ICrankMeter
    {
        private const int MinimumSmoothingIntervalMilliseconds = 10; // for fast movement
        private const int MaximumSmoothingIntervalMilliseconds = 60000; // for very slow movement
        private const int DefaultSmoothingIntervalMilliseconds = 500;

        private DateTimeOffset t0;
        private CircularBuffer<CrankChange> crankChanges;
        private int sumOfCrankChanges = 0;

        private DateTimeOffset lastMessageTimestamp;
        
        [DebuggerDisplay("{T}: {Delta}")]
        private class CrankChange
        {
            public static readonly CrankChange Zero = new CrankChange(0, 0);

            public int Delta;
            public int T;

            public CrankChange(int delta, int t)
            {
                this.Delta = delta;
                this.T = t;
            }
        }             
        
        /// <summary>
        /// Indicates if the object is ready to provide data. It needs to have received 2 updates
        /// timestamped withing the limit specified by <see cref="MaximumMessageInterval"/>.
        /// </summary>
        public bool HasData { get; private set; }
        
        /// <summary>
        /// The raw value read from the device.
        /// </summary>
        public int RawValue { get; private set; }

        /// <summary>
        /// RPM calculated from the crank positions and timestamps.
        /// </summary>
        public int RPM { get; private set; }

        /// <summary>
        /// Direction of crank movement.
        /// </summary>
        public CrankDirection Direction { get; private set; }

        /// <summary>
        /// The most recently read crank position;
        /// </summary>
        public int CrankPosition { get; private set; }

        /// <summary>
        /// The maximum number of milliseconds between messages for them to be considered sequential.
        /// </summary>
        public int MaximumMessageInterval { get; } = 500;

        /// <summary>
        /// The time period over which crank position changes will be measured to calculate RPM.
        /// </summary>
        public int SmoothingIntervalMilliseconds { get; private set; }


        public PositionalCrankMeter() : this(DefaultSmoothingIntervalMilliseconds)
        {
                
        }

        public PositionalCrankMeter(int smoothingIntervalMilliseconds)
        {
            if (smoothingIntervalMilliseconds < MinimumSmoothingIntervalMilliseconds || smoothingIntervalMilliseconds>MaximumSmoothingIntervalMilliseconds)
                throw new ArgumentOutOfRangeException(nameof(smoothingIntervalMilliseconds), 
                    $"Value should be from {MinimumSmoothingIntervalMilliseconds} to {MaximumSmoothingIntervalMilliseconds}.");

            this.crankChanges = new CircularBuffer<CrankChange>(smoothingIntervalMilliseconds, smoothingIntervalMilliseconds);
            this.SmoothingIntervalMilliseconds = smoothingIntervalMilliseconds;
        }
        public void Reset() => Reset(DateTimeOffset.MinValue);        

        private void Reset(DateTimeOffset timestamp)
        {
            this.Direction = CrankDirection.None;
            this.lastMessageTimestamp = timestamp;
            this.RPM = 0;
            this.RawValue = 0;
            this.t0 = timestamp;
            this.HasData = false;
            this.crankChanges.Clear();
            this.sumOfCrankChanges = 0;
        }               

        public void AddData(DateTimeOffset timestamp, int crankPosition, int crankRevolutionTime)
        {
            // Prevent invalid crank positions
            if (!CrankPositions.IsValidCrankPosition(crankPosition))
                throw new ArgumentOutOfRangeException(nameof(crankPosition));            

            // Ensure the sample is in the right order
            double timeSinceLastMessage = timestamp.Subtract(this.lastMessageTimestamp).TotalMilliseconds;
            if (timeSinceLastMessage < 0)
                throw new ArgumentException(Constants.StateTimestampError, nameof(timestamp));

            // Store the raw value
            this.RawValue = crankRevolutionTime;

            // If it's been too long since the last message, start over at this one.
            if (timeSinceLastMessage > this.MaximumMessageInterval)
            {
                this.Reset(timestamp);

                this.CrankPosition = crankPosition;
                this.crankChanges.Add(CrankChange.Zero);
                return;
            }

            // The change in location...
            int dp = CrankPositions.DirectionalCrankDelta(this.CrankPosition, crankPosition);

            // ..and the current position in time
            int t = (int)(timestamp - this.t0).TotalMilliseconds;

            // Off with the old...
            int lowerLimit = t - this.SmoothingIntervalMilliseconds;
            this.crankChanges.RemoveTailWhile(cc => cc.T < lowerLimit, cc => this.sumOfCrankChanges -= cc.Delta);

            // ...and on with the new.
            this.crankChanges.Add(new CrankChange(dp, t));
            this.sumOfCrankChanges += dp;

            // get the time period
            int dt = Math.Max(1, t - this.crankChanges.Tail.T);

            // Calculate the properties
            this.Direction = CrankPositions.GetDirection(this.sumOfCrankChanges);
            this.RPM = CrankPositions.CalculateRPM(this.sumOfCrankChanges, dt);
            this.HasData = true;
            this.CrankPosition = crankPosition;

            // Store the message time for future comparison
            this.lastMessageTimestamp = timestamp;
        }

        public void AddData(XDreamState state)
            => AddData(state.TimeStamp, state.CrankPosition, state.Crank);        
    }

}

