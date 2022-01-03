using System;

namespace Trixter.XDream.API.Filters
{

    /// <summary>
    /// Filter to track the average value over a specified time period. 
    /// No weighting by length of time between samples - relies on reasonably uniform sample intervals.
    /// </summary>
    internal class MeanValueFilter
    {
        private class Sample
        {
            public int Value;
            public int? Delta;
            public DateTimeOffset T;
            public Sample(DateTimeOffset t, int v, int? d)
            {
                this.Value = v;
                this.Delta = d;

                this.T = t;
            }
        }

        double periodMilliseconds;

        #region Cached values
        int? intValue;
        int? intDelta;
        double? deltaPerMillisecond;
        #endregion

        CircularBuffer<Sample> buffer;
        MeanCalculator meanValue, meanDelta;

        protected T CalculateCached<T>(Func<T> calculation, ref T? cached) where T:struct
        {
            if (cached.HasValue)
                return cached.Value;

            cached = calculation();

            return cached.Value;
        }

        public MeanValueFilter(int periodMilliseconds)
        {
            this.buffer = new CircularBuffer<Sample>(1000, 1000);
            this.periodMilliseconds = periodMilliseconds;
            this.meanValue = new MeanCalculator();
            this.meanDelta = new MeanCalculator();
        }


        private void StripOldSamples(DateTimeOffset t)
        {
            DateTimeOffset limit = t.AddMilliseconds(-periodMilliseconds);
            this.buffer.RemoveTailWhile(s => s.T < limit,
                s =>
                {
                    this.meanValue.Remove(s.Value);
                    if (s.Delta != null)
                    {
                        this.meanDelta.Remove(s.Delta.Value);
                        this.buffer.Tail.Delta = null;
                    }
                });
        }

        private void Add(int x, int? dx, DateTimeOffset t)
        {
            this.buffer.Add(new Sample(t, x, dx));
            this.meanValue.Add(x);
            if (dx != null)
                this.meanDelta.Add(dx.Value);

            this.StripOldSamples(t);

            // Clear the caches
            this.ClearCachedValues();
        }

        public void AddDelta(int dx, DateTimeOffset t)
        {
            if (this.buffer.Count == 0)
                throw new InvalidOperationException("Adding a delta requires an existing value in the buffer.");

            int x = this.buffer.Head.Value + dx;
            this.Add(x, dx, t);
        }

        public void Add(int x, DateTimeOffset t)
        {
            int? delta = this.buffer.Count > 0 ? (int?)(x - this.buffer.Head.Value) : null;

            this.Add(x, delta, t);
        }

        /// <summary>
        /// Mean value of sample values, mid-point rounded away from 0.
        /// </summary>
        public int IntValue => this.CalculateCached(() => (int)Math.Round(this.Value, 0, MidpointRounding.AwayFromZero), ref this.intValue);

        /// <summary>
        /// Mean value of sample deltas, mid-point rounded away from 0.
        /// </summary>
        public int IntDelta => this.CalculateCached(() => (int)Math.Round(this.Delta, 0, MidpointRounding.AwayFromZero), ref this.intDelta);


        /// <summary>
        /// Mean value of sample values.
        /// </summary>
        public double Value => this.meanValue.Mean; // no need to cache because the MeanCalculator object already does this.


        /// <summary>
        /// Mean value of sample deltas.
        /// </summary>
        public double Delta => this.meanDelta.Mean; // no need to cache because the MeanCalculator object already does this.


        /// <summary>
        /// Delta per millisecond.
        /// </summary>
        public double DeltaPerMillisecond => this.CalculateCached(() => this.meanDelta.Sum / this.Period, ref this.deltaPerMillisecond);


        /// <summary>
        /// The time difference between the first and last sample.
        /// </summary>
        public double Period => (this.buffer.Head.T - this.buffer.Tail.T).TotalMilliseconds;

        /// <summary>
        /// The <see cref="DateTimeOffset"/> of the most recent sample.
        /// </summary>
        public DateTimeOffset LastSampleTime => this.buffer.Count >0 ? this.buffer.Head.T : DateTimeOffset.MinValue;

        private void ClearCachedValues()
        {
            // Clear cached values
            this.intValue = null;
            this.deltaPerMillisecond = null;
            this.intDelta = null;
        }

        /// <summary>
        /// Reset the object to its initial state.
        /// </summary>
        public void Reset()
        {
            this.buffer.Clear();
            this.meanValue.Reset();
            this.meanDelta.Reset();
            this.ClearCachedValues();
        }
    }
}
