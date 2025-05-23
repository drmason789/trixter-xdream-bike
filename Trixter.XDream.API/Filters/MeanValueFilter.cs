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
        public MeanValueFilter(int periodMilliseconds):base(periodMilliseconds, new MeanCalculator(), new MeanCalculator())
        {
        }

        protected override void Trim(Sample s, double limit, out bool remove) 
        {
            this.Remove(s);

            remove = s.T < limit;
            
        }
        
        

       
    }

}
