using System;
using Trixter.XDream.API.Filters;

namespace Trixter.XDream.API
{
    /// <summary>
    /// Power meter that converts changes in wheel energy to power using the wheel's moment of inertia. 
    /// </summary>
    public class EnergyPowerMeter : IPowerMeter
    {
        private const int PeriodOfChangeTrackerMilliseconds = 1000;
        private const int MinimumSamplePeriodMilliseconds = 500;

        private MeanValueFilter energyTracker;
        private double momentOfInertia;
        
        public int Power { get; private set; }
            

        public EnergyPowerMeter(double flywheelMomentOfInertia)
        {
            this.momentOfInertia = flywheelMomentOfInertia;
            this.energyTracker = new MeanValueFilter(PeriodOfChangeTrackerMilliseconds);
        }

        public void Update(DateTimeOffset timestamp, int rpm)
        {
            double angularVelocity = rpm * Constants.RpmToRadiansPerSecond;
            double energy = 0.5 * this.momentOfInertia * angularVelocity * angularVelocity;

            this.energyTracker.Add(energy, timestamp);

            if (this.energyTracker.Period < MinimumSamplePeriodMilliseconds)
            {
                this.Power = 0;
                return;
            }

            double joulesPerSecond = this.energyTracker.DeltaPerMillisecond * Constants.MillisecondsPerSecond;

            if (joulesPerSecond > 0)
                this.Power = (int)Math.Round(joulesPerSecond, 0, MidpointRounding.AwayFromZero);
            else
                this.Power = 0;
            
        }
    }
}
