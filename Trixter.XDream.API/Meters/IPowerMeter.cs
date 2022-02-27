using System;

namespace Trixter.XDream.API.Meters
{
    public interface IPowerMeter
    {
        /// <summary>
        /// Power in Watts (W).
        /// </summary>
        int Power { get; }

        /// <summary>
        /// Update the power meter.
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="angularVelocity">The angular velocity in radians per second.</param>
        void Update(DateTimeOffset timestamp, double angularVelocity);
    }
}
