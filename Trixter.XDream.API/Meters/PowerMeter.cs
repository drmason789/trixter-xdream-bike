using System;
using Trixter.XDream.API.Filters;

namespace Trixter.XDream.API
{

    /// <summary>
    /// Power meter that converts changes in angular velocity  to power using the wheel's moment of inertia. 
    /// </summary>
    public class PowerMeter : IPowerMeter
    {
        private const int PeriodOfChangeTrackerMilliseconds = 1000;
        private const int MinimumSamplePeriodMilliseconds = 500;

        private MeanValueFilter rpmChangeTracker;
        private double momentOfInertia;
        private int? previousRPM;

        public int Power { get; private set; }

        public PowerMeter(double flywheelMomentOfInertia)
        {
            this.momentOfInertia = flywheelMomentOfInertia;
            this.rpmChangeTracker = new MeanValueFilter(PeriodOfChangeTrackerMilliseconds);
        }

        public void Update(DateTimeOffset timestamp, int rpm)
        {
            this.rpmChangeTracker.Add(rpm, timestamp);

            if (this.previousRPM == null || this.rpmChangeTracker.Period < MinimumSamplePeriodMilliseconds)
            {
                this.previousRPM = rpm;
                this.Power = 0;
                return;
            }
            
            double acceleration = this.rpmChangeTracker.DeltaPerMillisecond * Constants.MillisecondsPerMinute * Constants.RpmToRadiansPerSecond;

            if (acceleration > 0)
            {
                double angularVelocity = rpm * Constants.RpmToRadiansPerSecond;
                double torque = this.momentOfInertia * acceleration;
                double power = torque * angularVelocity;

                this.Power = (int) Math.Round(power, 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                this.Power = 0;
            }
            this.previousRPM = rpm;
        }
    }
}
