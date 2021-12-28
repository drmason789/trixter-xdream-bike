using System;
using Trixter.XDream.API;

namespace Trixter.XDream.Controller
{

    delegate void CrankPositionChangedDelegate(Pedaller sender, int newPosition);

    class Pedaller
    {
        private System.Timers.Timer timer;

        private int rpm=0;

        public event CrankPositionChangedDelegate CrankPositionChanged;

        protected void OnCrankPositionChanged()
        {
            this.CrankPositionChanged?.Invoke(this, this.CrankPosition);
        }
        public int CrankTime { get; private set; }


        public int CrankPosition { get; private set; } = CrankPositions.MinCrankPosition;

        public int RPM
        { 
            get => this.rpm;
            set 
            {

                value = Math.Min(300, Math.Max(0, value));

                if (this.rpm == value)
                    return;

                this.rpm = value;

                if (this.rpm == 0)
                {
                    this.timer.Stop();
                    this.CrankTime = 0;
                }
                else
                {
                    // calculate how many milliseconds per notch

                    int notchesPerMinute = this.RPM * CrankPositions.Positions;
                    double millisecondsPerNotch = (double)Constants.MillisecondsPerMinute / notchesPerMinute;
                    this.CrankTime = MappedCrankMeter.DefaultMappingRpmToRaw(this.rpm);
                    this.timer.Interval = millisecondsPerNotch;
                    this.timer.AutoReset = true;
                    this.timer.Start();
                }
            }
        
        }


        public Pedaller()
        {
            this.timer = new System.Timers.Timer();
            this.timer.Elapsed += (s, e) =>
            {
                this.CrankPosition = CrankPositions.Add(this.CrankPosition, 1);
                this.OnCrankPositionChanged();
            };
        }

    }
}
