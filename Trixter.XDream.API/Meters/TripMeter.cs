using System;

namespace Trixter.XDream.API
{
    public class TripMeter : ITripMeter
    {
        private IFlywheelMeter flywheelMeter;
        private ICrankMeter crankMeter;
        private DateTimeOffset lastUpdate;
        
        
        public DateTimeOffset? StartTime { get; private set; }

        public decimal FlywheelRevolutions { get; private set; }

        public decimal CrankRevolutions { get; private set; }

        public TripMeter(IFlywheelMeter flywheelMeter, ICrankMeter crankMeter)
        {
            this.crankMeter = crankMeter ?? throw new ArgumentNullException(nameof(crankMeter));
            this.flywheelMeter = flywheelMeter??throw new ArgumentNullException(nameof(flywheelMeter));
        }

        public void Reset()
        {
            this.FlywheelRevolutions = 0m;
            this.CrankRevolutions = 0m;
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
                double dt = ts.TotalMinutes;

                if (dt > 0)
                {
                    int fRPM = this.flywheelMeter.RPM;
                    int? cRPM = this.crankMeter.HasData && this.crankMeter.Direction==CrankDirection.Forward ? (int?)this.crankMeter.RPM : null;

                    if(fRPM>0)
                        this.FlywheelRevolutions += (decimal)(dt * this.flywheelMeter.RPM);

                    if (cRPM.GetValueOrDefault()>0)
                        this.CrankRevolutions += (decimal)(dt * this.crankMeter.RPM);
                }
            }
            this.lastUpdate = timestamp;
        }
    }
}
