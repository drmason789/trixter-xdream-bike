using System;
using System.Linq;

namespace Trixter.XDream.API
{
    /// <summary>
    /// Mapped crank meter that uses a functor to map crank time input values to RPM. 
    /// Precalculates the values in the constructor and stores in an array for fast mapping.
    /// Does not support back pedalling because the device sends 0 for that.
    /// </summary>
    public class MappedCrankMeter : ICrankMeter
    {
        internal const double crankSpeedConversion = 1d / 6e-6;
        public static readonly Func<int, int> DefaultMappingRawToRpm = x => x <= 0 ? 0 : (x >= 65534 ? 0 : (int)(crankSpeedConversion / x));
        public static readonly Func<int, int> DefaultMappingRpmToRaw = x => x <= 0 ? 0 :  Math.Min(65534, (int)(crankSpeedConversion / x));


        private int[] mapToRpm;
        private DateTimeOffset lastUpdate;

        public bool HasData { get; private set; }

        public CrankDirection Direction { get; private set; }

        public int RPM { get; private set; }

        public int CrankPosition { get; private set; }

        public int RawValue { get; private set; }

        public int MaximumMessageInterval => 500;

        public MappedCrankMeter() : this(null) // avoiding using a default parameter value for the unit testing
        {

        }
        
        public MappedCrankMeter(Func<int, int> getValue)
        {
            getValue = getValue ?? DefaultMappingRawToRpm;

            this.mapToRpm = Enumerable.Range(CrankPositions.MinCrankTimeReading, CrankPositions.MaxCrankTimeReading - CrankPositions.MinCrankTimeReading + 1)
                .Select(x => getValue(x)).ToArray();
        }

        public void AddData(DateTimeOffset timestamp, int crankPosition, int rawData)
        {
            if (this.lastUpdate > timestamp)
                throw new ArgumentException(Constants.StateTimestampError, nameof(timestamp));

            this.HasData = true;
            
            if(!CrankPositions.IsValidCrankPosition(crankPosition))
                throw new ArgumentOutOfRangeException(nameof(crankPosition));

            if(!CrankPositions.IsValidCrankTimeReading(rawData))
                throw new ArgumentOutOfRangeException(nameof(rawData));

            this.CrankPosition = crankPosition;
            this.RPM = this.mapToRpm[rawData];
            this.RawValue = rawData;

            this.Direction = this.RPM > 0 ? CrankDirection.Forward : CrankDirection.None;

            this.lastUpdate = timestamp;
        }

        public void AddData(XDreamState state) => this.AddData(state.TimeStamp, state.CrankPosition, state.Crank);
        

        public void Reset()
        {
            this.HasData = false;
            this.lastUpdate = DateTimeOffset.MinValue;
        }
    }
}
