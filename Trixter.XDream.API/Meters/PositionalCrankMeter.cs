using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Trixter.XDream.API.Filters;

namespace Trixter.XDream.API.Meters
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

        private MeanValueFilter crankChangeFilter;
        
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
        /// The angular velocity in radians per second calculated from crank positions and timestamps.
        /// </summary>
        public double AngularVelocity { get; private set; }

        /// <summary>
        /// RPM (revolutions per minute) calculated from the <see cref="AngularVelocity"/>.
        /// </summary>
        public int RPM => (int)Math.Round(this.AngularVelocity * Constants.RadiansPerSecondToRpm, 0, MidpointRounding.AwayFromZero);

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

            this.crankChangeFilter = new MeanValueFilter(smoothingIntervalMilliseconds);
            this.SmoothingIntervalMilliseconds = smoothingIntervalMilliseconds;
        }
     
        public void Reset()
        {
            this.Direction = CrankDirection.None;
            this.AngularVelocity = 0d;
            this.RawValue = 0;
            this.HasData = false;
            this.crankChangeFilter.Reset();
        }               

        public void AddData(DateTimeOffset timestamp, int crankPosition, int crankRevolutionTime)
        {
            // Prevent invalid crank positions
            if (!CrankPositions.IsValidCrankPosition(crankPosition))
                throw new ArgumentOutOfRangeException(nameof(crankPosition));            

            // Ensure the sample is in the right order
            double timeSinceLastMessage = timestamp.Subtract(this.crankChangeFilter.LastSampleTime).TotalMilliseconds;
            if (timeSinceLastMessage < 0)
                throw new ArgumentException(Constants.StateTimestampError, nameof(timestamp));

            // Store the raw value
            this.RawValue = crankRevolutionTime;

            // If it's been too long since the last message, start over at this one.
            if (timeSinceLastMessage > this.MaximumMessageInterval)
            {
                this.Reset();
                this.CrankPosition = crankPosition;
                this.crankChangeFilter.Add(crankPosition, timestamp);
                return;
            }

            // Update the change in position
            int dp = CrankPositions.DirectionalCrankDelta(this.CrankPosition, crankPosition);

            // Use the AddDelta method because dp is not necessarily new crank position - old crank position
            this.crankChangeFilter.AddDelta(dp, timestamp);

            // Calculate the properties
            double crankChangesPerMillisecond = this.crankChangeFilter.DeltaPerMillisecond;
            this.Direction = CrankPositions.GetDirection(Math.Sign(crankChangesPerMillisecond));
            this.AngularVelocity = CrankPositions.CalculateRadiansPerSecond(crankChangesPerMillisecond, 1);
             
            this.HasData = true;
            this.CrankPosition = crankPosition;
        }

        public void AddData(XDreamState state)
            => AddData(state.TimeStamp, state.CrankPosition, state.Crank);        
    }

}

