using System;
using System.Diagnostics;
using Trixter.XDream.API.Filters;

namespace Trixter.XDream.API.Testing.Experimental
{
    internal class StandardDeviationCalculator : MeanCalculator
    {
        private double? variance = null;
        private double? stddev = null;

        protected override string GetDebuggerDisplayString() => base.GetDebuggerDisplayString() + $" Var:{Variance} StdDev:{StandardDeviation}";

        /// <summary>
        /// Variance. Uses formula that avoids storing the samples.
        /// </summary>
        public double Variance => this.Calculate(() => this.SumOfSquares / this.N - this.Mean * this.Mean, ref this.variance);

        /// <summary>
        /// Standard deviation. Square root of <see cref="Variance"/>.
        /// </summary>
        public double StandardDeviation => this.Calculate(() => Math.Sqrt(this.Variance), ref this.stddev);

        public double SumOfSquares { get; protected set; }

        public StandardDeviationCalculator()
        {

        }

        protected override void DoAdd(double x)
        {
            base.DoAdd(x);
            this.SumOfSquares += x * x;
        }

        protected override void DoRemove(double x)
        {
            double xx = x * x;
            double newSumOfSquares = this.SumOfSquares - xx;

            if (newSumOfSquares < 0d)
                throw new InvalidOperationException("Operation would cause sum of squares to become negative.");
                       
            base.DoRemove(x);

            // Do this last in case the base method throws an exception.
            this.SumOfSquares = newSumOfSquares;
        }

        protected override void DoInvalidate()
        {
            this.variance = this.stddev = null;
            base.DoInvalidate();
        }
    }
}
