using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Filters
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class MeanCalculator
    {
        private double? mean = null;
        private string debuggerDisplay;

       protected virtual string GetDebuggerDisplayString() => $"N:{N} Sum:{Sum} Mean:{Mean}";
       protected string DebuggerDisplay      
               =>  this.debuggerDisplay ?? (this.debuggerDisplay = this.GetDebuggerDisplayString());
           
        protected double Calculate(Func<double> calculation, ref double? cached)
        {
            if (cached.HasValue)
                return cached.Value;

            if (this.N == 0)
                throw new InvalidOperationException();

            cached = calculation();

            return cached.Value;
        }

        public int N { get; protected set; } = 0;
        public double Mean => this.Calculate(() => this.Sum / this.N, ref this.mean);
        
        public double Sum { get; protected set; }
        
        public MeanCalculator()
        {

        }

        protected virtual void DoAdd(double x)
        {
            this.Sum += x;
        }

        protected virtual void DoRemove(double x)
        {
            double newSum = this.Sum - x;
            if (this.N == 1 && newSum != 0d)
                throw new InvalidOperationException("Removal would produce a non-zero sum for 0 items.");
            this.Sum = newSum;
        }

        protected virtual void DoInvalidate()
        {
            this.mean = null;
        }

        public void Add(double x)
        {
            this.DoAdd(x);
            this.N++;
            this.Invalidate();
        }

        public void Remove(double x)
        {
            if (this.N == 0)
                throw new InvalidOperationException();
            this.DoRemove(x);

            this.N--;
            this.Invalidate();
        }

        protected void Invalidate()
        {
            this.debuggerDisplay = null;
            this.DoInvalidate();
        }
    }
}
