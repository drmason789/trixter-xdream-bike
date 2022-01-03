using System;

namespace Trixter.XDream.API
{
    public class ThreadSafePowerMeter : ThreadLockable, IPowerMeter
    {
        IPowerMeter inner;

        public ThreadSafePowerMeter(IPowerMeter inner)
        {
            this.inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public int Power => this.DoLocked(()=>inner.Power);

        public void Update(DateTimeOffset timestamp, int rpm) => this.DoLocked(()=>this.inner.Update(timestamp, rpm));

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
