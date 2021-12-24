using System;

namespace Trixter.XDream.API
{
    public static class CrankPositions
    {
        public const int MinCrankPosition = 1;
        public const int MaxCrankPosition = 60;
        public const int Positions = MaxCrankPosition - MinCrankPosition + 1;

        public const int MaxCrankTimeReading = 65535; // No movement
        public const int MinCrankTimeReading = 0; // No movement

        public const double RevolutionsPerPosition = 1d / Positions;

        /// <summary>
        /// Determines if the specified value is a valid crank position.
        /// </summary>
        /// <param name="crankPosition"></param>
        /// <returns></returns>
        public static bool IsValidCrankPosition(int crankPosition)
            => crankPosition >= MinCrankPosition && crankPosition <= MaxCrankPosition;


        /// <summary>
        /// Determines if the specified value is a valid crank time reading.
        /// </summary>
        /// <param name="crankTimeReading"></param>
        /// <returns></returns>
        public static bool IsValidCrankTimeReading(int crankTimeReading)
            => crankTimeReading >= MinCrankTimeReading && crankTimeReading <= MaxCrankTimeReading;

        /// <summary>
        /// Determine a crank direction from an integer position change or directional measurement.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static CrankDirection GetDirection(int x)
        {
            if (x == 0) return CrankDirection.None;
            if (x > 0) return CrankDirection.Forward;
            return CrankDirection.Backward;
        }

        /// <summary>
        /// Determine the number of positions between the 2 specified positions.
        /// </summary>
        /// <param name="position0"></param>
        /// <param name="position1"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int CrankDelta(int position0, int position1)
        {
            if (!IsValidCrankPosition(position0))
                throw new ArgumentOutOfRangeException(nameof(position0));
            if (!IsValidCrankPosition(position1))
                throw new ArgumentOutOfRangeException(nameof(position1));

            int result = position1 - position0;
            if (result < 0) result += MaxCrankPosition;
            return result;
        }

        /// <summary>
        /// Calculates the number of positions between the first and second, and the direction
        /// using whichever difference has the smallest magnitude. If the direction is backward, the result is negative.
        /// Direction can be forced with the <see cref="forceDirection"/> parameter.
        /// </summary>
        /// <param name="position0">The first position.</param>
        /// <param name="position1">The second position.</param>
        /// <param name="forceDirection">Optional parameter to force a particular direction.
        /// Should not be <see cref="CrankDirection.None"/>.</param>
        /// <returns></returns>
        public static int DirectionalCrankDelta(int position0, int position1, CrankDirection? forceDirection=null)
        {
            if (position0 == position1)
            {
                return 0;
            }
            else if(forceDirection!=null)
            {
                CrankDirection direction = forceDirection.Value;

                if (direction == CrankDirection.None)
                    throw new ArgumentException(nameof(forceDirection));
                if (direction == CrankDirection.Forward)
                    return CrankPositions.CrankDelta(position0, position1);
                return -CrankPositions.CrankDelta(position1, position0);
            }
            else
            {
                int forwardDiff = CrankPositions.CrankDelta(position0, position1);
                int backwardDiff = -CrankPositions.CrankDelta(position1, position0);

                return (Math.Abs(forwardDiff) < Math.Abs(backwardDiff)) ? forwardDiff : backwardDiff;
            }
        }

        /// <summary>
        /// Add the specified delta to the specified crank position and map to a valid crank position if the result is not.
        /// </summary>
        /// <param name="position">The initial position.</param>
        /// <param name="delta">The change. Can be negative for backward motion.</param>
        /// <returns></returns>
        public static int Add(int position, int delta)
        {
            if (!IsValidCrankPosition(position))
                throw new ArgumentOutOfRangeException(nameof(position));

            if(delta==0)
                return position;
            
            int result = position-MinCrankPosition + delta;

            if(Math.Abs(result)>=Positions)
                result %= Positions;

            if (result < 0)
                result += Positions;
            result += MinCrankPosition;

            return result;

        }

        /// <summary>
        /// Calculate the revolutions per minute from the number of crank positions and the time taken.
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static int CalculateRPM(int positions, int milliseconds)
        {
            double crankPositionsPerMillisecond = Math.Abs((double)positions / milliseconds);
            double crankPositionsPerMinute = Constants.MillisecondsPerMinute * crankPositionsPerMillisecond;
            var result= (int)(0.5 + RevolutionsPerPosition * crankPositionsPerMinute);
            return result;
        }
    }

}
