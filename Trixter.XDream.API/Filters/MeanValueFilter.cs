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
        int? value;

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
            this.value = null;
            DateTimeOffset limit = t.AddMilliseconds(-periodMilliseconds);
            this.buffer.RemoveTailWhile(s => s.T < limit, s => this.statistics.Remove(s.Value));
        }


        public int Value
        {
            get 
            { 
                if(this.value == null)
                {
                    this.value =(int)(Math.Round(statistics.Mean, 0,MidpointRounding.AwayFromZero));
                }
                return this.value.Value;
            }
        }
    }
}
