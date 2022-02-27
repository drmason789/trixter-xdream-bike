using System;

namespace Trixter.XDream.API.Meters
{
    public class ThreadSafeFlywheelMeter : ThreadLockable, IFlywheelMeter
    {
        private readonly IFlywheelMeter inner;       

        public int RawValue => DoLocked(() => this.inner.RawValue);

        public double AngularVelocity => DoLocked(() => this.inner.AngularVelocity);
        public int RPM => DoLocked(() => this.inner.RPM);

        public ThreadSafeFlywheelMeter(IFlywheelMeter inner)
        {
            this.inner = inner;
        }

        public void AddData(DateTimeOffset timestamp, int rawValue) 
            => this.DoLocked(()=>this.inner.AddData(timestamp, rawValue));

        public void AddData(XDreamState state)
            => this.DoLocked(() => this.inner.AddData(state));

        public static ThreadSafeFlywheelMeter TryCreate(IFlywheelMeter inner)
        {
            if (inner == null)
                return null;
            if (inner is ThreadSafeFlywheelMeter tsfm)
                return tsfm;
            return new ThreadSafeFlywheelMeter(inner);
        }

    }
}
