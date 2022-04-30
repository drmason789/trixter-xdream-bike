﻿using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Filters
{
    [DebuggerDisplay("Count={Count} period={Period} v={Value} dv/ms={DeltaPerMillisecond}")]
    internal abstract class MeanValueFilterBase
    {
        private DateTimeOffset startTime;
        double periodMilliseconds;

        int? intValue;
        int? intDelta;
        double? deltaPerMillisecond;   
        SampleList samples;
        protected abstract IMeanCalculator MeanValue { get; }
        protected abstract IMeanCalculator MeanDelta { get; }

        /// <summary>
        /// The period over which the mean value is calculated, over which samples are kept.
        /// </summary>
        public int PeriodMilliseconds => (int)this.periodMilliseconds;

        /// <summary>
        /// Mean value of sample values, mid-point rounded away from 0.
        /// </summary>
        public int IntValue => this.CalculateCached(() => (int)Math.Round(this.Value, 0, MidpointRounding.AwayFromZero), ref this.intValue);

        /// <summary>
        /// Mean value of sample deltas, mid-point rounded away from 0.
        /// </summary>
        public int IntDelta => this.CalculateCached(() => (int)Math.Round(this.Delta, 0, MidpointRounding.AwayFromZero), ref this.intDelta);


        /// <summary>
        /// Mean value of sample values.
        /// </summary>
        public double Value => this.MeanValue.Mean; // no need to cache because the MeanCalculator object already does this.


        /// <summary>
        /// Mean value of sample deltas.
        /// </summary>
        public double Delta => this.MeanDelta.Mean; // no need to cache because the MeanCalculator object already does this.


        /// <summary>
        /// Delta per millisecond.
        /// </summary>
        public double DeltaPerMillisecond => this.CalculateCached(() => this.MeanDelta.Sum / this.Period, ref this.deltaPerMillisecond);


        /// <summary>
        /// The time difference between the first and last sample.
        /// </summary>
        public double Period => this.samples.Period;

        /// <summary>
        /// The <see cref="DateTimeOffset"/> of the most recent sample.
        /// </summary>
        public DateTimeOffset LastSampleTime => this.samples.Count > 0 ? this.startTime.AddMilliseconds(this.samples.Latest.T) : DateTimeOffset.MinValue;

        /// <summary>
        /// The number of samples in the buffer.
        /// </summary>
        public int Count => this.samples.Count;

        public MeanValueFilterBase(int periodMilliseconds)
        {
            this.periodMilliseconds = periodMilliseconds;
            this.samples = new SampleList();
            this.startTime = DateTimeOffset.MinValue;
        }


        public void Add(double value, DateTimeOffset timestamp)
        {
            double t = GetSampleTime(timestamp);
            Sample newSample = new Sample(t, value, value-this.samples.Latest?.Value);
            this.samples.Add(newSample);
            this.Add(newSample);
            this.Trim(t);

            // Clear the caches
            this.ClearCachedValues();
        }

        public void AddDelta(double delta, DateTimeOffset timestamp)
        {
            if (this.samples.Count == 0)
                throw new InvalidOperationException("Adding a delta requires an existing sample value.");

            this.Add(this.samples.Latest.Value + delta, timestamp);
        }

        /// <summary>
        /// Reset the object to its initial state.
        /// </summary>
        public void Reset()
        {
            this.startTime = DateTimeOffset.MinValue;
            this.MeanValue.Reset();
            this.MeanDelta.Reset();
            this.samples.Clear();
            this.ClearCachedValues();
        }

        protected T CalculateCached<T>(Func<T> calculation, ref T? cached) where T : struct
        {
            if (cached.HasValue)
                return cached.Value;

            cached = calculation();

            return cached.Value;
        }

        protected abstract void Add(Sample sample);
        protected abstract void Remove(Sample sample);

        private double GetSampleTime(DateTimeOffset t)
        {
            if (this.startTime == DateTimeOffset.MinValue)
            {
                this.startTime = t;
                return 0d;
            }
            return (t-this.startTime).TotalMilliseconds;
        }

        private void ClearCachedValues()
        {
            // Clear cached values
            this.intValue = null;
            this.deltaPerMillisecond = null;
            this.intDelta = null;
        }
     

        private void Trim(double t)
        {
            double limit = t-this.periodMilliseconds;

            this.samples.Trim(limit, (s,l)=>this.Trim(s, l));
        }

        protected abstract void Trim(Sample sample, double limit);
        
    }
}