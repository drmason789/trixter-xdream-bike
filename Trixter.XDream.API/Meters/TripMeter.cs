using System;

namespace Trixter.XDream.API.Meters
{
    public class TripMeter : ITripMeter
    {
        private XDreamMachine xdreamMachine;
        private DateTimeOffset lastUpdate;
        private decimal flywheelRadians;
        private decimal crankRadians;

        public DateTimeOffset? StartTime { get; private set; }

        public decimal FlywheelRevolutions => this.flywheelRadians * (decimal)Constants.RadiansToRevolutions;

        public decimal CrankRevolutions => this.crankRadians * (decimal)Constants.RadiansToRevolutions;

        public decimal Energy { get; private set; }

        public TripMeter(XDreamMachine xdreamMachine)
        {
            this.xdreamMachine = xdreamMachine;
            
        }

        public void Reset()
        {
            this.flywheelRadians = 0m;
            this.crankRadians = 0m;
            this.Energy = 0m;
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
                    var (flywheelMeter, crankMeter, powerMeter) = (this.xdreamMachine.FlywheelMeter, this.xdreamMachine.CrankMeter, this.xdreamMachine.PowerMeter);

                    double fw = flywheelMeter.AngularVelocity;
                    double? cw = crankMeter.HasData && crankMeter.Direction == CrankDirection.Forward ? (double?)crankMeter.AngularVelocity : null;
                    int power = powerMeter.Power;

                    if (fw > 0)
                        this.flywheelRadians += (decimal)(dt * flywheelMeter.AngularVelocity);

                    if (cw.GetValueOrDefault() > 0)
                        this.crankRadians += (decimal)(dt * crankMeter.AngularVelocity);

                    if (power > 0)
                        this.Energy += (decimal)(dt * power);
                }
            }
            this.lastUpdate = timestamp;
        }
    }
}
