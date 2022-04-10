using System;

namespace Trixter.XDream.API.Meters
{
    public class ThreadSafeTripMeter : ThreadLockable, ITripMeter 
    {
        private readonly ITripMeter inner;

        public ThreadSafeTripMeter(ITripMeter inner)
        {
            this.inner = inner;
        }

        public DateTimeOffset? StartTime => this.DoLocked(()=>inner.StartTime);

        public decimal FlywheelRevolutions => this.DoLocked(() => inner.FlywheelRevolutions);

        public decimal CrankRevolutions => this.DoLocked(() => inner.CrankRevolutions);

        public decimal Power => this.DoLocked(() => inner.Power);

        public void Reset() => this.DoLocked(() =>this.inner.Reset());

        public void Update(DateTimeOffset timestamp) => this.DoLocked(() => this.inner.Update(timestamp));

        public static ThreadSafeTripMeter TryCreate(ITripMeter inner)
        {
            if (inner == null)
                return null;
            if (inner is ThreadSafeTripMeter tstm)
                return tstm;
            return new ThreadSafeTripMeter(inner);
        }
    }
}
