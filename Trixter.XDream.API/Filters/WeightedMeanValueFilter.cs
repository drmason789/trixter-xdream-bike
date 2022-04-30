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

        /// <summary>
        /// Collect statistics for the sample.
        /// </summary>
        /// <param name="sample"></param>
        protected override void Add(Sample sample)
        {
            double dT = sample.dT;
            this.meanValue.Add(sample.Value, dT);
            if (sample.Delta != null)
                this.meanDelta.Add(sample.Delta.Value, dT);
        }

        /// <summary>
        /// Remove statistcs for the sample.
        /// </summary>
        /// <param name="sample"></param>
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
                // Move the last sample that's beyond the limit up to the limit
                // so that the period of the filter is the full length.
                double olddT = next.dT;
                current.T = limit;
                double newdT = next.dT;

                this.meanValue.Update(next.Value, olddT, newdT);
                if (next.Delta != null)
                    this.meanDelta.Update(next.Delta.Value, olddT, newdT);
            }
        }

    }

}
