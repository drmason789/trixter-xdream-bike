using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Trixter.XDream.API.Filters
{

    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class WeightedMeanCalculator : IMeanCalculator
    {
        private double? mean = null;
        private string debuggerDisplay;

        protected string GetDebuggerDisplayString() => $"TotalWeight:{TotalWeight} Sum:{Sum} WeightedMean:{Mean}";
        protected string DebuggerDisplay
                => this.debuggerDisplay ?? (this.debuggerDisplay = this.GetDebuggerDisplayString());

        protected double Calculate(Func<double> calculation, ref double? cached)
        {
            if (cached.HasValue)
                return cached.Value;

            if (this.TotalWeight == 0)
                throw new InvalidOperationException();

            cached = calculation();

            return cached.Value;
        }

        /// <summary>
        /// The total weight of items in the calculation.
        /// </summary>
        public double TotalWeight { get; protected set; } = 0;

        /// <summary>
        /// The mean: sum divided by the total weight of items.
        /// </summary>
        public double Mean => this.mean.GetValueOrDefault(this.Calculate(() => this.Sum / this.TotalWeight, ref this.mean));

        /// <summary>
        /// The sum of the items added.
        /// </summary>
        public double Sum { get; protected set; }

        public WeightedMeanCalculator()
        {

        }       

        /// <summary>
        /// Add an item.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="weight"></param>
        public void Add(double value, double weight)
        {
            this.Sum += value * weight;
            this.TotalWeight += weight;
            this.Invalidate();
        }
        
        /// <summary>
        /// Remove an item. If the removal will result in an invalid calculation or state of the object, an <see cref="InvalidOperationException"/> is thrown.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="weight"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Remove(double value, double weight)
        {
            this.AssertValidWeight(weight);
            this.Add(value, -weight);
        }
        
        /// <summary>
        /// Change the weight of a value in one operation, avoiding overheads of calling <see cref="Add"/> and <see cref="Remove"/> separately.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldWeight"></param>
        /// <param name="newWeight"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Update(double value, double oldWeight, double newWeight)
        {
            this.AssertValidWeight(oldWeight);
            double dW = newWeight - oldWeight;
            this.Add(value, dW);
        }

        /// <summary>
        /// Invalidate the cached values.
        /// </summary>
        protected void Invalidate()
        {
            this.debuggerDisplay = null;
            this.mean = null;
        }

        /// <summary>
        /// Rest the object to its initial state.
        /// </summary>
        public void Reset()
        {
            this.TotalWeight = 0;
            this.mean = null;
            this.Sum = 0;
            this.Invalidate();

        }

        /// <summary>
        /// Assert that removal of the specified weight will not result in negative total weight and throw an <see cref="InvalidOperationException"/>
        /// if it will.
        /// </summary>
        /// <param name="weight"></param>
        /// <exception cref="InvalidOperationException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AssertValidWeight(double weight)
        {
            if (weight > this.TotalWeight)
                throw new InvalidOperationException("Removal would produce negative total weight.");
        }
    }
}
