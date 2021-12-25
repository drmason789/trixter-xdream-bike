using System;

namespace Trixter.XDream.API
{
    public interface IFlywheelMeter
    {
        int RawValue { get; }

        int RPM { get; }

        void AddData(DateTimeOffset timestamp, int rawValue);

        void AddData(XDreamState state);


    }

}

