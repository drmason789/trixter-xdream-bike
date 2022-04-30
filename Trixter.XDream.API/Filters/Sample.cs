﻿using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Filters
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class Sample
    {
        private string DebuggerDisplay => $"{T:0.0000}: v={Value} d={Delta}";

        protected Sample previous, next;

        public double Value;
        public double? Delta => this.Value - this.previous?.Value;
        public double T;
        
        public double WeightedValue => this.Value * this.dT;
        public double? WeightedDelta => this.Delta * this.dT;

        public double dT => this.Previous == null ? 0 : (this.T - this.Previous.T);

        public Sample Previous
        {
            get => this.previous;
            set
            {
                
                if (value != null)
                {
                    if (value.Next != null)
                        throw new InvalidOperationException("Next sample already set.");
                    else
                        value.next = this;
                }
                this.previous = value;
            }
        }
        public Sample Next
        {
            get => this.next;
            set
            {
                if (value != null)
                {
                    if (value.Previous != null)
                        throw new InvalidOperationException("Previous sample already set.");
                    else
                        value.previous = this;
                }
                this.next = value;
            }
        }


        public Sample(double t, double v)
        {
            this.Value = v;           

            this.T = t;
        }
    }

}
