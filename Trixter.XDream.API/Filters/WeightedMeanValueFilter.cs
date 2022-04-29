using System;
using System.Collections.Generic;
using System.Diagnostics;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Filters
{
    
    /// <summary>
    /// Filter to track the average value over a specified time period. 
    /// </summary>
    [DebuggerDisplay("Count={Count} period={Period} v={Value} dv/ms={DeltaPerMillisecond}")]
    internal class WeightedMeanValueFilter : MeanValueFilterBase
    {
        WeightedMeanCalculator meanValue;
        WeightedMeanCalculator meanDelta;

        protected override IMeanCalculator MeanValue => this.meanValue;
        protected override IMeanCalculator MeanDelta => this.meanDelta;

        public WeightedMeanValueFilter(int periodMilliseconds) : base(periodMilliseconds)
        {
            this.meanValue = new WeightedMeanCalculator();
            this.meanDelta = new WeightedMeanCalculator();            
        }

        protected override void Add(Sample sample)
        {
            double dT = sample.dT;
            this.meanValue.Add(sample.Value, dT);
            if (sample.Delta != null)
                this.meanDelta.Add(sample.Delta.Value, dT);
        }

        protected override void Remove(Sample sample)
        {
            double dT = sample.dT;
            this.meanValue.Remove(sample.Value, dT);
            if (sample.Delta != null)
                this.meanDelta.Remove(sample.Delta.Value, dT);
        }

        protected override void Trim(Sample current, double limit)
        {
            this.Remove(current);
            Sample next = current.Next;
            if (next?.T >= limit)
            {
                Remove(next);
                current.T = limit;
                Add(next);
            }
        }

    }

}
