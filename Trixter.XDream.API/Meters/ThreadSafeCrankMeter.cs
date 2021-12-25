using System;

namespace Trixter.XDream.API
{

    public class ThreadSafeCrankMeter : ThreadLockable, ICrankMeter
    {
        
        private ICrankMeter inner;

        public bool HasData => this.DoLocked(() => this.inner.HasData);

        public CrankDirection Direction => this.DoLocked(() => this.inner.Direction);

        public int RPM => this.DoLocked(() => this.inner.RPM);

        public int CrankPosition => this.DoLocked(() => this.inner.CrankPosition);

        public int RawValue => this.DoLocked(() => this.inner.RawValue);

        public int MaximumMessageInterval => this.DoLocked(() => this.inner.MaximumMessageInterval);

        public void AddData(DateTimeOffset timestamp, int crankPosition, int rawData) => this.DoLocked(()=>this.inner.AddData(timestamp, crankPosition, rawData));

        public void AddData(XDreamState state) => this.DoLocked(()=>this.inner.AddData(state));

        public void Reset()
        {
            lock (this.SyncRoot)
                this.inner.Reset();
        }

        public ThreadSafeCrankMeter(ICrankMeter inner)
        {
            this.inner = inner;
        }

        public static ThreadSafeCrankMeter TryCreate(ICrankMeter inner)
        {
            if (inner == null)
                return null;
            if (inner is ThreadSafeCrankMeter tscm)
                return tscm;
            return new ThreadSafeCrankMeter(inner);
        }
    }
}
