using System;

namespace Trixter.XDream.API.Generators
{
    /// <summary>
    /// Cadence provider that generates crank data using the specified RPM value.
    /// Not able to back-pedal.
    /// </summary>
    public class AutoCranker : ICadenceProvider
    {
        public const int MaxRPM = 2000;

        // 0-based starting position
        private double exactCrankPosition;

        private int crankPosition;
        private int rpm;
        private DateTimeOffset lastUpdate;
        private double positionsPerMillisecond = double.PositiveInfinity;

        public event CrankPositionChangedDelegate<ICadenceProvider> CrankPositionChanged;

        public double MillisecondsPerPosition { get; private set; }

        public int CrankPosition
        {
            get => this.crankPosition;
            set
            {
                if (!CrankPositions.IsValidCrankPosition(value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                this.crankPosition = value;
                this.lastUpdate = DateTimeOffset.MinValue;
                this.exactCrankPosition = value - CrankPositions.MinCrankPosition;
            }
        }

        public int RPM
        {
            get => this.rpm;
            set
            {
                if (value < 0 || value > MaxRPM)
                    throw new ArgumentOutOfRangeException(nameof(value));

                this.rpm = value;

                if (value == 0)
                {
                    this.MillisecondsPerPosition = double.PositiveInfinity;
                    this.positionsPerMillisecond = 0;
                }
                else
                {
                    this.MillisecondsPerPosition = (double)Constants.MillisecondsPerMinute / this.rpm / CrankPositions.Positions;
                    this.positionsPerMillisecond = 1d / this.MillisecondsPerPosition;
                }
            }
        }

        protected virtual void OnCrankPositionChanged(int delta)
        {
            this.CrankPositionChanged?.Invoke(this, delta);
        }

        public AutoCranker()
        {
            this.CrankPosition = CrankPositions.MinCrankPosition;
            this.RPM = 0;
        }

        public void Update(DateTimeOffset timestamp)
        {
            if (this.lastUpdate == DateTimeOffset.MinValue)
            {
                this.lastUpdate = timestamp;
                return;
            }

            double dT = (timestamp - this.lastUpdate).TotalMilliseconds;

            if (dT < 0)
                throw new ArgumentException(Constants.StateTimestampError, nameof(timestamp));

            this.lastUpdate = timestamp;

            double dP = dT * positionsPerMillisecond;
            this.exactCrankPosition += dP;

            int newCrankPosition = CrankPositions.MinCrankPosition + (int)this.exactCrankPosition;

            // now that the exact crank position has been used, clip it to the correct range
            if (this.exactCrankPosition >= CrankPositions.Positions)
                this.exactCrankPosition -= Math.Truncate(this.exactCrankPosition);

            int delta = newCrankPosition - this.crankPosition;

            if (newCrankPosition != this.crankPosition)
            {
                this.crankPosition = CrankPositions.Add(this.crankPosition, delta);
                this.OnCrankPositionChanged(delta);
            }
        }

    }
}
