using System;
using System.Diagnostics;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Filters
{


    /// <summary>
    /// Filter to track the average value over a specified time period. 
    /// No weighting by length of time between samples - relies on reasonably uniform sample intervals.
    /// </summary>
    [DebuggerDisplay("Count={Count} period={Period} v={Value} dv/ms={DeltaPerMillisecond}")]
    internal class MeanValueFilter : MeanValueFilterBase
    {
        MeanCalculator meanValue, meanDelta;
        protected override IMeanCalculator MeanValue => this.meanValue;
        protected override IMeanCalculator MeanDelta => this.meanDelta;

        public MeanValueFilter(int periodMilliseconds):base(periodMilliseconds)
        {
            this.meanValue = new MeanCalculator();
            this.meanDelta = new MeanCalculator();
        }

        protected override void Trim(Sample s, double limit) => this.Remove(s);
        
        protected override void Add(Sample sample)
        {   
            this.meanValue.Add(sample.Value);
            if (sample.Delta != null)
                this.meanDelta.Add(sample.Delta.Value);           
        }

        protected override void Remove(Sample sample)
        {
            this.meanValue.Remove(sample.Value);
            if (sample.Delta != null)
                this.meanDelta.Remove(sample.Delta.Value);
        }

       
    }

}
