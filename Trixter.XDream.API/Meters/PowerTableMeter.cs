using System;

namespace Trixter.XDream.API.Meters
{
    /// <summary>
    /// Power meter that uses a lookup table for crank speed and resistance.
    /// </summary>
    public class PowerTableMeter : IPowerMeter
    {
        private XDreamMachine xdreamMachine;

        public int Power { get; private set; }


        public PowerTableMeter(XDreamMachine xdm)
        {
            this.Power = 0;
            this.xdreamMachine = xdm;
        }
        
        /// <summary>
        /// Update with the latest data.
        /// </summary>
        /// <param name="timestamp">Unused</param>
        /// <param name="v">Unused</param>
        public void Update(DateTimeOffset timestamp, double v)
        {
            XDreamMachine xdm = this.xdreamMachine;
            
            bool applyingPower = xdm.CrankMeter.Direction == CrankDirection.Forward && xdm.CrankMeter.RPM > 0;

            if (applyingPower)
            {
                this.Power = PowerTable.GetWattsFromRPM(this.xdreamMachine.CrankMeter.RPM, this.xdreamMachine.Resistance);
            }
            else 
                this.Power = 0;
        }
    }
}