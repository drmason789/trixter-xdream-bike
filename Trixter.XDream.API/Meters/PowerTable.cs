using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Trixter.XDream.API.Meters
{

    /// <summary>
    /// From a table taken from an X-Dream configuration file, this static class provides a bilinearly interpolated table of (RPM, Resistance, Watts)
    /// for every (int, int) from (30, 0) to (120, 250).
    /// </summary>
    internal static class PowerTable
    {
        [DebuggerDisplay("{RPM} RPM | {Resistance} R | {Power} W")]
        private class PowerPoint
        {
            public int RPM { get; }
            public int Resistance { get;  }
            public double Power { get; }

            public PowerPoint(int rpm, int resistance, double power)
            {
                this.RPM = rpm;
                this.Resistance = resistance;
                this.Power = power;
            }
        }

        private const int minimumRPM = 30;
        private const int maximumRPM = 120;
        private const int maximumResistance = 250;
        private const int minimumResistance = 0;

        /// <summary>
        /// Values taken from an X-Dream configuration file
        /// </summary>
        internal static double[,] values = 
        {
            {30, 0, 4.68},
            {30, 10, 5.77},
            {30, 20, 6.86},
            {30, 30, 7.95},
            {30, 40, 9.04},
            {30, 50, 10.13},
            {30, 60, 13.75},
            {30, 70, 17.38},
            {30, 80, 21},
            {30, 90, 24.63},
            {30, 100, 28.25},
            {30, 110, 32.42},
            {30, 120, 36.59},
            {30, 130, 40.77},
            {30, 140, 44.94},
            {30, 150, 49.11},
            {30, 160, 52.31},
            {30, 170, 55.5},
            {30, 180, 58.7},
            {30, 190, 61.89},
            {30, 200, 65.09},
            {30, 210, 66.87},
            {30, 220, 68.65},
            {30, 230, 70.42},
            {30, 240, 72.2},
            {30, 250, 73.98},
            {40, 0, 5.79},
            {40, 10, 6.96},
            {40, 20, 8.13},
            {40, 30, 9.29},
            {40, 40, 10.46},
            {40, 50, 11.63},
            {40, 60, 17.27},
            {40, 70, 22.91},
            {40, 80, 28.54},
            {40, 90, 34.18},
            {40, 100, 39.82},
            {40, 110, 47.69},
            {40, 120, 55.55},
            {40, 130, 63.42},
            {40, 140, 71.28},
            {40, 150, 79.15},
            {40, 160, 84.57},
            {40, 170, 89.99},
            {40, 180, 95.4},
            {40, 190, 100.82},
            {40, 200, 106.24},
            {40, 210, 109.37},
            {40, 220, 112.5},
            {40, 230, 115.62},
            {40, 240, 118.75},
            {40, 250, 121.88},
            {50, 0, 7.09},
            {50, 10, 8.73},
            {50, 20, 10.37},
            {50, 30, 12.01},
            {50, 40, 13.65},
            {50, 50, 15.29},
            {50, 60, 23.02},
            {50, 70, 30.76},
            {50, 80, 38.49},
            {50, 90, 46.23},
            {50, 100, 53.96},
            {50, 110, 65.73},
            {50, 120, 77.5},
            {50, 130, 89.28},
            {50, 140, 101.05},
            {50, 150, 112.82},
            {50, 160, 121.57},
            {50, 170, 130.32},
            {50, 180, 139.07},
            {50, 190, 147.82},
            {50, 200, 156.57},
            {50, 210, 161.46},
            {50, 220, 166.34},
            {50, 230, 171.23},
            {50, 240, 176.11},
            {50, 250, 181},
            {60, 0, 7.85},
            {60, 10, 9.64},
            {60, 20, 11.43},
            {60, 30, 13.21},
            {60, 40, 15},
            {60, 50, 16.79},
            {60, 60, 26.91},
            {60, 70, 37.04},
            {60, 80, 47.16},
            {60, 90, 57.29},
            {60, 100, 67.41},
            {60, 110, 83.71},
            {60, 120, 100.01},
            {60, 130, 116.32},
            {60, 140, 132.62},
            {60, 150, 148.92},
            {60, 160, 161.5},
            {60, 170, 174.09},
            {60, 180, 186.67},
            {60, 190, 199.26},
            {60, 200, 211.84},
            {60, 210, 219.79},
            {60, 220, 227.75},
            {60, 230, 235.7},
            {60, 240, 243.66},
            {60, 250, 251.61},
            {70, 0, 7.02},
            {70, 10, 9.56},
            {70, 20, 12.1},
            {70, 30, 14.64},
            {70, 40, 17.18},
            {70, 50, 19.72},
            {70, 60, 31.66},
            {70, 70, 43.6},
            {70, 80, 55.55},
            {70, 90, 67.49},
            {70, 100, 79.43},
            {70, 110, 99.66},
            {70, 120, 119.89},
            {70, 130, 140.13},
            {70, 140, 160.36},
            {70, 150, 180.59},
            {70, 160, 199.42},
            {70, 170, 218.25},
            {70, 180, 237.09},
            {70, 190, 255.92},
            {70, 200, 274.75},
            {70, 210, 285.29},
            {70, 220, 295.84},
            {70, 230, 306.38},
            {70, 240, 316.93},
            {70, 250, 327.47},
            {80, 0, 11.21},
            {80, 10, 14.45},
            {80, 20, 17.69},
            {80, 30, 20.94},
            {80, 40, 24.18},
            {80, 50, 27.42},
            {80, 60, 42.48},
            {80, 70, 57.54},
            {80, 80, 72.61},
            {80, 90, 87.67},
            {80, 100, 102.73},
            {80, 110, 128.44},
            {80, 120, 154.15},
            {80, 130, 179.85},
            {80, 140, 205.56},
            {80, 150, 231.27},
            {80, 160, 253.8},
            {80, 170, 276.33},
            {80, 180, 298.85},
            {80, 190, 321.38},
            {80, 200, 343.91},
            {80, 210, 359.11},
            {80, 220, 374.3},
            {80, 230, 389.5},
            {80, 240, 404.69},
            {80, 250, 419.89},
            {90, 0, 13.95},
            {90, 10, 17.98},
            {90, 20, 22.01},
            {90, 30, 26.03},
            {90, 40, 30.06},
            {90, 50, 34.09},
            {90, 60, 52.98},
            {90, 70, 71.87},
            {90, 80, 90.77},
            {90, 90, 109.66},
            {90, 100, 128.55},
            {90, 110, 159.29},
            {90, 120, 190.03},
            {90, 130, 220.76},
            {90, 140, 251.5},
            {90, 150, 282.24},
            {90, 160, 312.59},
            {90, 170, 342.94},
            {90, 180, 373.3},
            {90, 190, 403.65},
            {90, 200, 434},
            {90, 210, 449.53},
            {90, 220, 465.06},
            {90, 230, 480.6},
            {90, 240, 496.13},
            {90, 250, 511.66},
            {100, 0, 10.66},
            {100, 10, 14.86},
            {100, 20, 19.06},
            {100, 30, 23.27},
            {100, 40, 27.47},
            {100, 50, 31.67},
            {100, 60, 50.99},
            {100, 70, 70.32},
            {100, 80, 89.64},
            {100, 90, 108.97},
            {100, 100, 128.29},
            {100, 110, 162.32},
            {100, 120, 196.34},
            {100, 130, 230.37},
            {100, 140, 264.39},
            {100, 150, 298.42},
            {100, 160, 337.06},
            {100, 170, 375.71},
            {100, 180, 414.35},
            {100, 190, 453},
            {100, 200, 491.64},
            {100, 210, 512.57},
            {100, 220, 533.5},
            {100, 230, 554.44},
            {100, 240, 575.37},
            {100, 250, 596.3},
            {110, 0, 10.32},
            {110, 10, 15.17},
            {110, 20, 20.03},
            {110, 30, 24.88},
            {110, 40, 29.74},
            {110, 50, 34.59},
            {110, 60, 56.34},
            {110, 70, 78.09},
            {110, 80, 99.85},
            {110, 90, 121.6},
            {110, 100, 143.35},
            {110, 110, 182.15},
            {110, 120, 220.95},
            {110, 130, 259.76},
            {110, 140, 298.56},
            {110, 150, 337.36},
            {110, 160, 382.87},
            {110, 170, 428.38},
            {110, 180, 473.9},
            {110, 190, 519.41},
            {110, 200, 564.92},
            {110, 210, 591.47},
            {110, 220, 618.03},
            {110, 230, 644.58},
            {110, 240, 671.14},
            {110, 250, 697.69},
            {120, 0, 12.28},
            {120, 10, 18.05},
            {120, 20, 23.84},
            {120, 30, 29.61},
            {120, 40, 35.39},
            {120, 50, 41.16},
            {120, 60, 67.05},
            {120, 70, 92.93},
            {120, 80, 118.83},
            {120, 90, 144.71},
            {120, 100, 170.6},
            {120, 110, 216.77},
            {120, 120, 262.95},
            {120, 130, 309.14},
            {120, 140, 355.31},
            {120, 150, 401.49},
            {120, 160, 455.65},
            {120, 170, 509.81},
            {120, 180, 563.98},
            {120, 190, 618.14},
            {120, 200, 672.3},
            {120, 210, 703.9},
            {120, 220, 735.51},
            {120, 230, 767.1},
            {120, 240, 798.71},
            {120, 250, 830.31}
        };
        
        private static PowerPoint[,] powerTable;
        private static double[][] fullPowerTable;
        
        static PowerTable()
        {
            PowerPoint[] powerPoints = Enumerable.Range(0, values.GetLength(0))
                .Select(i => new PowerPoint((int)values[i, 0], (int)values[i, 1], values[i, 2]))
                .ToArray();

            powerTable = new PowerPoint[(maximumRPM-minimumRPM)/10 + 1, (maximumResistance-minimumResistance)/10+1];

            foreach (var pp in powerPoints)
                powerTable[(pp.RPM / 10) - 3, pp.Resistance / 10] = pp;

            // TODO: check that only the 1st column is 0

            // Precalculate the values for all parameter values.
            fullPowerTable = new double[maximumRPM - minimumRPM + 1][];
            for (int rpm = minimumRPM; rpm <= maximumRPM; rpm++)
            {
                double [] row = fullPowerTable[rpm - minimumRPM] = new double[maximumResistance - minimumResistance + 1];

                for (int resistance = minimumResistance; resistance <= maximumResistance; resistance++)
                    row[resistance] = GetWattsFromTable(rpm, resistance);
            }
        }

        private static double GetWattsFromTable(int rpm, int resistance)
        {
            rpm = ClipRPM(rpm);
            resistance = ClipResistance(resistance);

            int y = rpm / 10 - 3, x = resistance / 10;
            int yr = rpm % 10, xr = resistance % 10;

            if(yr==0 && xr==0)
                return powerTable[y, x].Power;

            if (yr == 0)
                return LinearInterpolation(new [] { powerTable[y, x], powerTable[y, x + 1] }, resistance, p => p.Resistance);
            
            if (xr == 0)
                return LinearInterpolation(new [] { powerTable[y, x], powerTable[y+1, x] }, rpm, p => p.RPM);
            
            PowerPoint[,] region = new PowerPoint[2, 2];

            region[0, 0] = powerTable[y, x];
            region[0, 1] = powerTable[y, x + 1];
            region[1, 0] = powerTable[y + 1, x];
            region[1, 1] = powerTable[y + 1, x + 1];


            double power = BilinearInterpolation(region, rpm, resistance);

            return power;
        }

        private static double LinearInterpolation(PowerPoint[] line, int p, Func<PowerPoint, int> getProperty)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));
            if(getProperty==null)
                throw new ArgumentNullException(nameof(getProperty));
            if (line.Length != 2)
                throw new ArgumentException("Line should have 2 power points.", nameof(line));
            int p0= getProperty(line[0]), p1 = getProperty(line[1]);

            if (p0 >= p1)
                throw new ArgumentException("Power points are not in increasing order of the specified property.",
                    nameof(line));
            if (p < p0 || p > p1)
                throw new ArgumentException("Point is not between power points.", nameof(p));

            return ((p1-p)*line[0].Power+(p-p0)*line[1].Power) / (p1-p0);
        }

        private static double BilinearInterpolation(PowerPoint [,] pp,int rpm, int r)
        {
            if (pp[0, 0].Resistance != pp[1, 0].Resistance || pp[0, 1].Resistance != pp[1,1].Resistance
                || pp[0, 0].RPM != pp[0,1].RPM || pp[1,0].RPM != pp[1,1].RPM)
                throw new ArgumentException("Power points do not form a rectangle.", nameof(pp));
            
            double[,] w = new double[2, 2];
            
            double x0 = pp[0,0].Resistance, x1 = pp[0,1].Resistance;
            double y0 = pp[0,0].RPM, y1 = pp[1,0].RPM;
            double x = r, y = rpm;

            double dx = x1 - x0, dy = y1 - y0, dxdy = dx * dy, dy1 = y1 - y, dy0= y-y0, dx1=x1-x, dx0=x-x0;

            w[0, 0] = dx1 * dy1;
            w[0, 1] = dx1 * dy0;
            w[1, 0] = dx0 * dy1;
            w[1, 1] = dx0 * dy0;

            double power = (w[0,0]*pp[0,0].Power + w[0,1]*pp[0,1].Power + w[1,0]*pp[1,0].Power + w[1,1]*pp[1,1].Power)* dxdy * 0.0001;
            return power;
        }
        private static int ClipRPM(int rpm) => Math.Max(30, Math.Min(120, rpm));
        private static int ClipResistance(int resistance) => Math.Max(0, Math.Min(250, resistance));
        
        /// <summary>
        /// Gets the power corresponding to the crank speed and resistance.
        /// </summary>
        /// <param name="rpm">Crank speed in RPM</param>
        /// <param name="resistance"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int GetWattsFromRPM(int rpm, int resistance)
        {
            if (rpm < minimumRPM) return 0; // no power if going backwards
            if (resistance > maximumResistance || resistance < minimumResistance)
                throw new ArgumentOutOfRangeException(nameof(resistance));

            int index = Math.Min(rpm, maximumRPM)-minimumRPM;
            
            return (int)(0.5 + fullPowerTable[index][resistance]);
        }

        /// <summary>
        /// Gets the resistance level required for the specified crank speed to require the specified power.
        /// </summary>
        /// <param name="rpm">The crank speed.</param>
        /// <param name="watts">The desired power level.</param>
        /// <returns></returns>
        public static int ResistanceFromWatts(int rpm, int watts)
        {
            rpm = ClipRPM(rpm);

            double[] rpmSeries = fullPowerTable[rpm - minimumRPM];
            int index = Array.BinarySearch(rpmSeries, watts);

            return Math.Abs(index);
            
        }
    }
    
}
