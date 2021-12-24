using System;
using System.Linq;

namespace Trixter.XDream.API.Testing
{
    /// <summary>
    /// Experimental class to establish a relationship between the raw crank time value that comes from the 
    /// device, with an RPM that is calculated from crank position data.
    /// </summary>
    public class StatisticsGatheringCrankMeter : ICrankMeter
    {
        private const int MaxCrankRPM = 300;

        private ICrankMeter inner;
        Statistics[] rpmStats, rawStats;
        MeanValueFilter rawFilter, rpmFilter;

        public StatisticsGatheringCrankMeter(ICrankMeter inner, int rawDataFilterPeriod)
        {
            this.inner = inner;
            this.rawFilter = new MeanValueFilter(rawDataFilterPeriod);
            this.rpmFilter = new MeanValueFilter(rawDataFilterPeriod);

            this.Reset();
        }

        public bool HasData => this.inner.HasData;

        public CrankDirection Direction => this.inner.Direction;

        public int RPM => this.inner.RPM;

        public int CrankPosition => this.inner.CrankPosition;

        public int RawValue => this.inner.RawValue;

        public int MaximumMessageInterval => this.inner.MaximumMessageInterval;

        public void AddData(DateTimeOffset timestamp, int crankPosition, int rawData)
        {
            this.rawFilter.Add(rawData, timestamp);

            rawData = this.rawFilter.Value;

            this.inner.AddData(timestamp, crankPosition, rawData);

            if (this.inner.HasData)
            {
                this.rpmFilter.Add(inner.RPM, timestamp);

                int rpm = this.rpmFilter.Value;

                if (rawData > 0 && rpm < this.rpmStats.Length)
                {
                    this.rpmStats[rpm] += rawData;
                    this.rawStats[rawData] += rpm;                    
                }
            }

        }

        public void AddData(XDreamState state) => AddData(state.TimeStamp, state.CrankPosition, state.Crank);
        

        public void Reset()
        {
            this.inner.Reset();
            this.rpmStats = Enumerable.Range(0, MaxCrankRPM).Select(x=>new Statistics()).ToArray();
            this.rawStats = Enumerable.Range(0, 65536).Select(x => new Statistics()).ToArray();

        }

        public string GetRpmToRawData()
        {
            return "RPM,Mean Raw,StdDev Raw\r\n"+
            string.Join("\r\n",this.rpmStats.Select((s, i) => new { RPM = i, Raw = s }).Where(x => x.Raw.N > 0).Select(x => $"{x.RPM},{x.Raw.Mean:0},{x.Raw.StandardDeviation:0.00}"));
        }

        public string GetRawToRpmData()
        {
            return "Raw,Mean RPM,StdDev RPM\r\n" +
            string.Join("\r\n", this.rawStats.Select((s, i) => new { Raw = i, RPM = s }).Where(x => x.RPM.N > 0).Select(x => $"{x.Raw},{x.RPM.Mean:0},{x.RPM.StandardDeviation:0.00}"));
        }

        public void GetLinearCoefficients(out double slope, out double intercept) 
        {
            var dataPoints = this.rpmStats.Select((s, i) => new { RPM = i, Raw = s }).Where(x => x.Raw.N > 0);

            LeastSquaresInterpolator interpolator = new LeastSquaresInterpolator();
            foreach (var dataPoint in dataPoints)
                interpolator.Add(1d / dataPoint.Raw.Mean, dataPoint.RPM);

            interpolator.GetCoefficients(out var r2, out slope, out intercept);
        }
                
    }
}
