using System;

namespace Trixter.XDream.API.Filters
{

    /// <summary>
    /// Filter to track the average value over a specified time period. 
    /// No weighting by length of time between samples - relies on reasonably uniform sample intervals.
    /// </summary>
    internal class MeanValueFilter
    {
        double periodMilliseconds;
        int? intValue;
        double? valuePerMillisecond;

        private class Sample
        {
            public int Value;
            public DateTimeOffset T;
            public Sample(int v, DateTimeOffset t)
            {
                this.Value = v;
                this.T = t;
            }
        }      

        CircularBuffer<Sample> buffer;
        MeanCalculator statistics;

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
            this.statistics = new MeanCalculator();
        }

        public void Add(int x, DateTimeOffset t)
        {
            this.buffer.Add(new Sample(x, t));
            this.statistics.Add(x);

            DateTimeOffset limit = t.AddMilliseconds(-periodMilliseconds);
            this.buffer.RemoveTailWhile(s => s.T < limit, s => this.statistics.Remove(s.Value));

            // Clear the caches
            this.intValue = null;
            this.valuePerMillisecond = null;
        }


        public int IntValue => this.CalculateCached(() => (int)Math.Round(this.Value, 0, MidpointRounding.AwayFromZero), ref this.intValue);

        public double Value => this.statistics.Mean; // no need to cache becasue the MeanCalculator object already does this.
        
        public double ValuePerMillisecond => this.CalculateCached(()=>this.statistics.Sum / this.Period, ref this.valuePerMillisecond);
        
        /// <summary>
        /// The time difference between the first and last sample.
        /// </summary>
        public double Period => (this.buffer.Head.T - this.buffer.Tail.T).TotalMilliseconds;

        /// <summary>
        /// The <see cref="DateTimeOffset"/> of the most recent sample.
        /// </summary>
        public DateTimeOffset LastSampleTime => this.buffer.Count >0 ? this.buffer.Head.T : DateTimeOffset.MinValue;

        public void Reset()
        {
            this.buffer.Clear();
            this.statistics = new MeanCalculator();
            this.intValue = null;
            this.valuePerMillisecond = null;
        }
    }
}
