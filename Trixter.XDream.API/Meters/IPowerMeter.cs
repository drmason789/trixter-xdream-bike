using System;

namespace Trixter.XDream.API
{
    public interface IPowerMeter
    {
        /// <summary>
        /// Power in Watts (W).
        /// </summary>
        int Power { get; }

        void Update(DateTimeOffset timestamp, int rpm);
    }
}
