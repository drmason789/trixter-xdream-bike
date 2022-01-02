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
        double? value;

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
            this.intValue = null;
            this.value = null;
            DateTimeOffset limit = t.AddMilliseconds(-periodMilliseconds);
            this.buffer.RemoveTailWhile(s => s.T < limit, s => this.statistics.Remove(s.Value));
        }


        public int IntValue
        {
            get 
            { 
                if(this.intValue == null)
                {
                    this.intValue =(int)(Math.Round(this.Value, 0,MidpointRounding.AwayFromZero));
                }
                return this.intValue.Value;
            }
        }

        public double Value
        {
            get
            {
                if (this.value == null)
                {
                    this.value = statistics.Mean;
                }
                return this.value.Value;
            }
        }

        public void Reset()
        {
            this.buffer.Clear();
            this.statistics = new MeanCalculator();
            this.intValue = null;
            this.value = null;
        }
    }
}
