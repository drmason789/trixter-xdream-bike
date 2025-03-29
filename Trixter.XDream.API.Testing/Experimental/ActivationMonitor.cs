using System;
using System.Collections.Generic;
using Trixter.XDream.API.Filters;

namespace Trixter.XDream.API.Testing.Experimental
{
    public class ActivationMonitor
    {
        private readonly Queue<Sample> samples = new Queue<Sample>();
        private double activationThreshold = 0.7;
        private double deactivationThreshold = 0.3;
        private int samplingPeriod = 1000;
        private bool isCurrentlyActive = false;

        private int activeSampleCount = 0;  // Running sum of active samples


        /// <summary>
        /// Represents a sample with a timestamp and activation state.
        /// </summary>
        private class Sample
        {
            public long Timestamp { get; }
            public bool IsActive { get; }
            public Sample(long timestamp, bool isActive)
            {
                this.Timestamp = timestamp;
                this.IsActive = isActive;
            }
        }

        /// <summary>
        /// Function used to get the current time in ticks. 
        /// Defaults to DateTime.UtcNow.Ticks.
        /// </summary>
        private readonly Func<long> getTime;

        protected virtual void OnActivationChanged(bool e) => ActivationChanged?.Invoke(this, e);

        /// <summary>
        /// Event triggered on activation or deactivation.
        /// The bool parameter is true for activation and false for deactivation.
        /// </summary>
        public event EventHandler<bool> ActivationChanged;

        /// <summary>
        /// Gets the current activation state.
        /// </summary>
        public bool IsActive => this.isCurrentlyActive;

        /// <summary>
        /// Gets or sets the activation threshold.
        /// </summary>
        public double ActivationThreshold
        {
            get => this.activationThreshold;
            set => this.activationThreshold = Clamp(value, this.deactivationThreshold, 1.0);
        }

        /// <summary>
        /// Gets or sets the deactivation threshold.
        /// </summary>
        public double DeactivationThreshold
        {
            get => this.deactivationThreshold;
            set => this.deactivationThreshold = Clamp(value, 0.0, this.activationThreshold);
        }

        /// <summary>
        /// Gets or sets the sampling period in milliseconds.
        /// </summary>
        public int SamplingPeriod
        {
            get => (int)this.samplingPeriod;
            private set => this.samplingPeriod = Math.Max(value, 1);
        }

        /// <summary>
        /// Constructor with optional time provider for testing.
        /// </summary>
        /// <param name="samplingPeriod">The sample period in the unit of the <see cref="getTime"/> function.</param>
        /// <param name="getTime">A function providing the current time in ticks (for testing purposes).</param>
        public ActivationMonitor(int samplingPeriod, Func<long> getTime = null)
        {
            this.getTime = getTime ?? (() => DateTime.UtcNow.Ticks);
            this.SamplingPeriod = samplingPeriod;
        }

        /// <summary>
        /// Updates the activation state and triggers the event if thresholds are crossed.
        /// </summary>
        /// <param name="isActive">Indicates whether the flag is active.</param>
        public void Update(bool isActive)
        {
            this.samples.Enqueue(new Sample(this.getTime(), isActive));

            if (isActive)
            {
                this.activeSampleCount++;
            }

            this.CleanUpOldSamples();
            double meanActivation = this.CalculateMeanActivation();

            if (!this.isCurrentlyActive && meanActivation >= this.activationThreshold)
            {
                this.isCurrentlyActive = true;
                this.OnActivationChanged(true);
            }
            else if (this.isCurrentlyActive && meanActivation < this.deactivationThreshold)
            {
                this.isCurrentlyActive = false;
                this.OnActivationChanged(false);
            }
        }

        /// <summary>
        /// Removes outdated samples and adjusts the active sample count.
        /// </summary>
        private void CleanUpOldSamples()
        {
            long cutoffTicks = this.getTime() - this.samplingPeriod;

            while (this.samples.Count > 0 && this.samples.Peek().Timestamp < cutoffTicks)
            {
                var expiredSample = this.samples.Dequeue();

                if (expiredSample.IsActive)
                {
                    this.activeSampleCount--;
                }
            }
        }

        /// <summary>
        /// Calculates the mean activation over the current sample window.
        /// </summary>
        private double CalculateMeanActivation()
        {
            if (this.samples.Count == 0) return 0.0;

            return (double)this.activeSampleCount / this.samples.Count;
        }

        /// <summary>
        /// Clamps the value between the specified minimum and maximum.
        /// </summary>
        private static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
