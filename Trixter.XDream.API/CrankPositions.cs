using System;

namespace Trixter.XDream.API
{
    internal static class XDreamCrankPositions
    {
        public const int MinCrankPosition = 1;
        public const int MaxCrankPosition = 60;
        public const int CrankPositions = MaxCrankPosition - MinCrankPosition + 1;

        public const int MaxCrankReading = 65535;
        public const int MinCrankReading = 0;

        /// <summary>
        /// Determines if the specified value is a valid crank position.
        /// </summary>
        /// <param name="crankPosition"></param>
        /// <returns></returns>
        public static bool IsValidCrankPosition(int crankPosition)
            => crankPosition >= MinCrankPosition && crankPosition <= MaxCrankPosition;

        /// <summary>
        /// Determines if the specified value is a valid crank reading.
        /// </summary>
        /// <param name="crankReading"></param>
        /// <returns></returns>
        public static bool IsValidCrankReading(int crankReading)
            => crankReading >= MinCrankReading && crankReading <= MaxCrankReading;

        /// <summary>
        /// Add the specified delta to the specified crank position.
        /// </summary>
        /// <param name="position">The initial position.</param>
        /// <param name="delta">The change. Can be negative for backward motion.</param>
        /// <returns></returns>
        public static int Add(int position, int delta)
        {
            if (!IsValidCrankPosition(position))
                throw new ArgumentOutOfRangeException(nameof(position));

            int result = position + delta;

            if (result > MaxCrankPosition)
                result -= MaxCrankPosition;
            else if (result < MinCrankPosition)
                result += MaxCrankPosition;

            return result;

        }
    }

}
