using System;

namespace Trixter.XDream.API
{
    public class MappedFlywheelMeter : IFlywheelMeter
    {
        public static readonly Func<int, int> DefaultFlywheelRawToRpm = x => x <= 0 ? int.MaxValue : (x >= 65534 ? 0 : (int)(600000 / x));

        private Func<int, int> flywheelRawToRpm;

        public MappedFlywheelMeter() : this(null) 
        {
        }

        public MappedFlywheelMeter(Func<int, int> rawToRpm)
        {
            this.flywheelRawToRpm = rawToRpm ?? DefaultFlywheelRawToRpm;
        }

        public int RawValue { get; private set; }

        public int RPM { get; private set; }

        public void AddData(DateTimeOffset timestamp, int rawValue)
        {
            this.RawValue = rawValue;

            this.RPM = this.flywheelRawToRpm(rawValue);
        }

        public void AddData(XDreamState state) => this.AddData(state.TimeStamp, state.Flywheel);
       
    }

}

