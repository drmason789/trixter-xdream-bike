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
        public WeightedMeanValueFilter(int periodMilliseconds, bool useMidPoint=false) : base(periodMilliseconds, new WeightedMeanCalculator(), new WeightedMeanCalculator(), useMidPoint)
        {
          
        }

        protected override void Trim(Sample current, double limit, out bool remove)
        {
            this.Remove(current);
            Sample next = current.Next;
            if (next?.T > limit)
            {
                // Move the last sample that's beyond the limit up to the limit
                // so that the period of the filter is the full length.
                double olddT = next.dT;
                current.T = limit;
                double newdT = next.dT;
                                
                this.MeanValue.Update(this.UseMidPoint ? next.MidPoint:next.Value, olddT, newdT);
                if (next.Delta != null)
                    this.MeanDelta.Update(next.Delta.Value, olddT, newdT);
            }
            remove = current.T < limit;
        }

    }

}
