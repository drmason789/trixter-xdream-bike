using System;
using System.Diagnostics;

namespace Trixter.XDream.API
{

    /// <summary>
    /// Uses a faster <see cref="MappedCrankMeter"/> object for forward cadence of faster than <see cref="PositionalUpperLimitRPM"/> RPM,
    /// and a slower <see cref="PositionalCrankMeter"/> object for slower forward cadence, and all backward cadence.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class HybridCrankMeter : ICrankMeter
    {
        public const int PositionalUpperLimitRPM = 20;

        private MappedCrankMeter mapped;
        private PositionalCrankMeter positional;
        
        private int lastCrankPosition, lastRawValue;
        DateTimeOffset lastUpdate;
        

        internal string DebuggerDisplay
            => $"HasData: {HasData} RPM:{RPM} RawValue:{RawValue} Direction:{Direction} | M.RPM: {(mapped.HasData ? mapped.RPM.ToString() : "-")} | P.RPM: {(positional.HasData ? positional.RPM.ToString() : "-")}";

        public bool HasData => this.Current.HasData;

        public CrankDirection Direction => this.Current.Direction;

        public int RPM => this.Current.RPM;

        public int CrankPosition => this.Current.CrankPosition;

        public int RawValue => this.Current.RawValue;

        public int MaximumMessageInterval => 500;

        protected ICrankMeter Current { get; set; }


        public HybridCrankMeter() : this(null)
        {

        }

        public HybridCrankMeter(Func<int,int> getMappedRpm)
        {
            this.mapped = new MappedCrankMeter(getMappedRpm);
            this.positional = new PositionalCrankMeter(1100);

            // Start with the costly meter which can handle slow RPM and backpedalling
            this.Current = this.positional;
        }

        public void AddData(DateTimeOffset timestamp, int crankPosition, int rawData)
        {
            bool fastForward = this.Current == this.mapped;

            if (fastForward)
            {
                this.mapped.AddData(timestamp, crankPosition, rawData);

                bool notForward = rawData == 0;
                bool slow = !this.mapped.HasData || this.mapped.RPM <= PositionalUpperLimitRPM;

                if (slow || notForward)
                {
                    if (!this.positional.HasData && this.lastUpdate != DateTimeOffset.MinValue)
                        this.positional.AddData(this.lastUpdate, this.lastCrankPosition, this.lastRawValue);
                    this.positional.AddData(timestamp, crankPosition, rawData);

                    this.Current = this.positional;
                    this.mapped.Reset();
                }
            }
            else
            {
                this.positional.AddData(timestamp, crankPosition, rawData);

                if (this.positional.HasData && this.positional.Direction == CrankDirection.Forward && this.positional.RPM > PositionalUpperLimitRPM)
                {
                    this.mapped.AddData(timestamp, crankPosition, rawData);

                    this.positional.Reset();

                    // switch to the mapped meter
                    this.Current = this.mapped;
                }
            }

            this.lastUpdate = timestamp;
            this.lastCrankPosition = crankPosition;
            this.lastRawValue = rawData;
        }

        public void AddData(XDreamState message) => this.AddData(message.TimeStamp, message.CrankPosition, message.Crank);

        public void Reset()
        {
            this.mapped.Reset();
            this.positional.Reset();
            this.lastUpdate = DateTimeOffset.MinValue;
        }
    }
}
