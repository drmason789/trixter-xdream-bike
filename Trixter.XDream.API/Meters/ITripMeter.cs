using System;
using System.Collections.Generic;
using System.Text;

namespace Trixter.XDream.API.Meters
{
    public interface ITripMeter
    {
        DateTimeOffset? StartTime { get; }
        decimal FlywheelRevolutions { get; }
        decimal CrankRevolutions { get; }

        void Update(DateTimeOffset timestamp);
        void Reset();
    }
}
