using System;

namespace Trixter.XDream.API.Meters
{
    public class TripMeter : ITripMeter
    {
        private IFlywheelMeter flywheelMeter;
        private ICrankMeter crankMeter;
        private DateTimeOffset lastUpdate;
        private decimal flywheelRadians;
        private decimal crankRadians;        
        
        public DateTimeOffset? StartTime { get; private set; }

        public decimal FlywheelRevolutions => this.flywheelRadians*(decimal)Constants.RadiansToRevolutions;

        public decimal CrankRevolutions => this.crankRadians*(decimal)Constants.RadiansToRevolutions;

        public TripMeter(IFlywheelMeter flywheelMeter, ICrankMeter crankMeter)
        {
            this.crankMeter = crankMeter ?? throw new ArgumentNullException(nameof(crankMeter));
            this.flywheelMeter = flywheelMeter??throw new ArgumentNullException(nameof(flywheelMeter));
        }

        public void Reset()
        {
            this.flywheelRadians = 0m;
            this.crankRadians = 0m;
            this.lastUpdate = DateTimeOffset.MinValue;
            this.StartTime = null;
        }

        public void Update(DateTimeOffset timestamp)
        {
            if (this.StartTime == null)
            {
                this.StartTime = timestamp;
            }
            else
            {
                TimeSpan ts = timestamp - this.lastUpdate;
                double dt = ts.TotalSeconds;

                if (dt > 0)
                {
                    double fw = this.flywheelMeter.AngularVelocity;
                    double? cw = this.crankMeter.HasData && this.crankMeter.Direction==CrankDirection.Forward ? (double?)this.crankMeter.AngularVelocity : null;

                    if(fw>0)
                        this.flywheelRadians += (decimal)(dt * this.flywheelMeter.AngularVelocity);

                    if (cw.GetValueOrDefault()>0)
                        this.crankRadians += (decimal)(dt * this.crankMeter.AngularVelocity);
                }
            }
            this.lastUpdate = timestamp;
        }
    }
}
