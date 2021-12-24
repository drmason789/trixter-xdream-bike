using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Testing
{
    [DebuggerDisplay("N:{N} Sum:{Sum} Mean:{Mean} Var:{Variance} StdDev:{StandardDeviation}")]
    public class Statistics
    {
        private double? mean=null;
        private double? variance=null;
        private double? stddev = null;

        private double Calculate(Func<double> calculation, ref double? cached)
        {
            if(cached.HasValue)
                return cached.Value;

            if (this.N == 0)
                throw new InvalidOperationException();

            cached = calculation();

            return cached.Value;
        }

        public int N { get; protected set; } = 0;
        public double Mean => this.Calculate(() => this.Sum / this.N, ref this.mean);

        /// <summary>
        /// Variance. Uses formula that avoids storing the samples.
        /// </summary>
        public double Variance => this.Calculate(() => this.SumOfSquares / this.N - this.Mean*this.Mean, ref this.variance);

        /// <summary>
        /// Standard deviation. Square root of <see cref="Variance"/>.
        /// </summary>
        public double StandardDeviation => this.Calculate(() => Math.Sqrt(this.Variance), ref this.stddev);

        public double Sum { get; protected set; }
        public double SumOfSquares { get; protected set; }

        public Statistics()
        {

        }

        public void Add(double x)
        {
            this.N++;
            this.Sum += x;
            this.SumOfSquares += x * x;
            this.Invalidate();
        }

        public void Remove(double x)
        {
            if (this.N == 0)
                throw new InvalidOperationException();

            double xx = x * x;
            double newSumOfSquares = this.SumOfSquares - xx;


            if (newSumOfSquares < 0d)
                throw new InvalidOperationException("Operation would cause sum of squares to become negative.");
            
            this.Invalidate();
            this.N--;
            this.Sum -= x;
            this.SumOfSquares = newSumOfSquares;
        }

        protected virtual void Invalidate()
        {
            this.mean = this.variance = this.stddev = null;
        }

        
        public static Statistics operator+(Statistics s, double x)
        {
            s.Add(x);
            return s;
        }

    }
}
