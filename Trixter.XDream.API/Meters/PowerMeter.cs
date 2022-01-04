using System;
using Trixter.XDream.API.Filters;

namespace Trixter.XDream.API.Meters
{

    /// <summary>
    /// Power meter that converts changes in angular velocity  to power using the wheel's moment of inertia. 
    /// </summary>
    public class PowerMeter : IPowerMeter
    {
        private const int PeriodOfChangeTrackerMilliseconds = 1000;
        private const int MinimumSamplePeriodMilliseconds = 500;

        private MeanValueFilter angularVelocityTracker;
        private double momentOfInertia;

        public int Power { get; private set; }

        public PowerMeter(double flywheelMomentOfInertia)
        {
            this.momentOfInertia = flywheelMomentOfInertia;
            this.angularVelocityTracker = new MeanValueFilter(PeriodOfChangeTrackerMilliseconds);
        }

        public void Update(DateTimeOffset timestamp, int rpm)
        {

            double angularVelocity = rpm * Constants.RpmToRadiansPerSecond;

            this.angularVelocityTracker.Add(angularVelocity, timestamp);

            if (this.angularVelocityTracker.Period < MinimumSamplePeriodMilliseconds)
            {
                this.Power = 0;
                return;
            }
            
            double acceleration = this.angularVelocityTracker.DeltaPerMillisecond * Constants.MillisecondsPerSecond;

            if (acceleration > 0)
            {
                double torque = this.momentOfInertia * acceleration;
                double power = torque * angularVelocity;

                this.Power = (int) Math.Round(power, 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                this.Power = 0;
            }
        }
    }
}
