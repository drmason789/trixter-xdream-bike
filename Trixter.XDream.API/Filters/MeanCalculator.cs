using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Filters
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class MeanCalculator : IMeanCalculator
    {
        private double? mean = null;
        private string debuggerDisplay;

        protected virtual string GetDebuggerDisplayString() => $"N:{N} Sum:{Sum} Mean:{Mean}";
        protected string DebuggerDisplay
                => this.debuggerDisplay ?? (this.debuggerDisplay = this.GetDebuggerDisplayString());

        protected double Calculate(Func<double> calculation, ref double? cached)
        {
            if (cached.HasValue)
                return cached.Value;

            if (this.N == 0)
                throw new InvalidOperationException();

            cached = calculation();

            return cached.Value;
        }

        /// <summary>
        /// The number of items in the calculation.
        /// </summary>
        public int N { get; protected set; } = 0;

        /// <summary>
        /// The mean: sum divided by the number of items.
        /// </summary>
        public double Mean => this.Calculate(() => this.Sum / this.N, ref this.mean);

        /// <summary>
        /// The sum of the items added.
        /// </summary>
        public double Sum { get; protected set; }

        public MeanCalculator()
        {

        }


        #region Template methods
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

        protected virtual void DoReset()
        {
            this.mean = null;
            this.Sum = 0;
        }

        #endregion

        /// <summary>
        /// Add an item.
        /// </summary>
        /// <param name="x"></param>
        public void Add(double x, double weight=1)
        {
            this.DoAdd(x);
            this.N++;
            this.Invalidate();
        }

        /// <summary>
        /// Remove an item. If the removal will result in an invalid calculation or state of the object, an <see cref="InvalidOperationException"/> is thrown.
        /// </summary>
        /// <param name="x"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Remove(double x, double weight=1)
        {
            if (this.N == 0)
                throw new InvalidOperationException();
            this.DoRemove(x);

            this.N--;
            this.Invalidate();
        }

        public void Update(double value, double oldWeight, double newWeight)
        {
            // weights are ignored
        }

        /// <summary>
        /// Invalidate the cached values.
        /// </summary>
        protected void Invalidate()
        {
            this.debuggerDisplay = null;
            this.DoInvalidate();
        }

        /// <summary>
        /// Rest the object to its initial state.
        /// </summary>
        public void Reset()
        {
            this.N = 0;
            this.DoReset();
            this.Invalidate();

        }
    }
}
