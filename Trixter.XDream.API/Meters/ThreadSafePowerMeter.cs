using System;

namespace Trixter.XDream.API.Meters
{
    public class ThreadSafePowerMeter : ThreadLockable, IPowerMeter
    {
        IPowerMeter inner;

        public ThreadSafePowerMeter(IPowerMeter inner)
        {
            this.inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public int Power => this.DoLocked(()=>inner.Power);

        public void Update(DateTimeOffset timestamp, double angularVelocity) => this.DoLocked(()=>this.inner.Update(timestamp, angularVelocity));

        public static ThreadSafePowerMeter TryCreate(IPowerMeter inner)
        {
            if (inner == null)
                return null;
            if (inner is ThreadSafePowerMeter tsm)
                return tsm;
            return new ThreadSafePowerMeter(inner);
        }
    }
}
