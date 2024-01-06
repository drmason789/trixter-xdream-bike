using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Meters
{
    /// <summary>
    /// Stores a uniform grid of samples, and provides bilinear interpolation within the boundaries.
    /// </summary>
    public class BilinearInterpolator
    {
        [DebuggerDisplay("X:{X} | Y:{Y} | Value:{Value}")]
        private class Sample
        {
            public int X { get; }
            public int Y { get; }
            public double Value { get; }

            public Sample(int x, int y, double value)
            {
                this.X = x;
                this.Y = y;
                this.Value = value;
            }
        }

        
        private Sample[][] values = null;
        private int minX, maxX, minY, maxY, incX, incY;
        
        private int Clip(int v, int min, int max) => Math.Max(min, Math.Min(max, v));
        private int ClipX(int x) => this.Clip(x, minX, maxX);
        private int ClipY(int y) => this.Clip(y, minY, maxY);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="xmin">Minimum X coordinate of the sample set.</param>
        /// <param name="xmax">Maximum X coordinate of the sample set. <see cref="xmax"/>-<see cref="xmin"/> should be evenly divisible by <see cref="xi"/></param>
        /// <param name="xi">Distance between samples in X direction.</param>
        /// <param name="ymin">Minimum Y coordinate of the sample set.</param>
        /// <param name="ymax">Maximum Y coordinate of the sample set. <see cref="ymax"/>-<see cref="ymin"/> should be evenly divisible by <see cref="yi"/></param>
        /// <param name="yi">Distance between samples in Y direction.</param>
        /// <param name="getValue"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>

        public BilinearInterpolator(int xmin, int xmax, int xi, int ymin, int ymax, int yi, Func<int,int,double> getValue)
        {
            if(xi<0) throw new ArgumentOutOfRangeException(nameof(xi));
            if(yi<0) throw new ArgumentOutOfRangeException( nameof(yi));
            if(xmin>xmax) throw new ArgumentOutOfRangeException(nameof(xmin));
            if (ymin>ymax) throw new ArgumentOutOfRangeException(nameof(ymin));
            if(getValue==null) throw new ArgumentNullException(nameof(getValue));

            int deltaX = xmax - xmin, deltaY = ymax - ymin;

            if (deltaX % xi != 0) throw new ArgumentException("Increment should evenly divide the domain.", nameof(xi));
            if (deltaY % yi != 0) throw new ArgumentException("Increment should evenly divide the domain.", nameof(yi));

            int countX = 1+deltaX / xi, countY = 1+deltaY/yi;

            (this.minX, this.minY, this.maxX, this.maxY) = (xmin, ymin, xmax, ymax);
            (this.incX, this.incY) = (xi, yi);
            
            this.values = new Sample[countY][];

            for (int y = ymin, ly=0; y <= ymax; y += yi, ly++)
            {
                this.values[ly] = new Sample[countX];

                for (int x = xmin, lx=0; x <= xmax; x += xi, lx++)
                {
                    try
                    {
                        this.values[ly][lx] = new Sample(x, y, getValue(x, y));
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        
        public double this[int x, int y] => this.GetValue(y, x);

        private double GetValue(int y, int x)
        {
            x = this.ClipX(x);
            y = this.ClipY(y);

            // point offset by the sample origin
            (int yo, int xo) = (y-this.minY, x - this.minX);

            // distance into the quad
            (int yr, int xr) = (yo % this.incY, xo % this.incX );

            // local position in the sample array
            (int yl, int xl) = (yo / this.incY, xo / this.incX);

            if (yr == 0 && xr == 0)
                // it's exactly on a sample
                return this.values[yl][xl].Value;

            if (yr == 0)
                // On the lower Y edge
                return Interpolate(new[] { this.values[yl][xl], this.values[yl][ xl + 1] }, x, p => p.X);

            if (xr == 0)
                // On the lower X edge
                return Interpolate(new[] { this.values[yl][ xl], this.values[yl + 1][ xl] }, y, p => p.Y);

            // Collect the surrounding samples
            Sample[,] region = new Sample[2, 2];
            region[0, 0] = this.values[yl][ xl];
            region[0, 1] = this.values[yl][ xl + 1];
            region[1, 0] = this.values[yl + 1][ xl];
            region[1, 1] = this.values[yl + 1][ xl + 1];
            
            // Interpolate bilinearly.
            double result = Interpolate(region, x, y);

            return result;
        }

        /// <summary>
        /// Interpolate linearly.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="p"></param>
        /// <param name="getProperty"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        private static double Interpolate(Sample[] line, int p, Func<Sample, int> getProperty)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));
            if (getProperty == null)
                throw new ArgumentNullException(nameof(getProperty));
            if (line.Length != 2)
                throw new ArgumentException("Line should have 2 sample points.", nameof(line));
            int p0 = getProperty(line[0]), p1 = getProperty(line[1]);

            if (p0 >= p1)
                throw new ArgumentException("Sample points are not in increasing order of the specified property.",
                    nameof(line));
            if (p < p0 || p > p1)
                throw new ArgumentException("Point is not between sample points.", nameof(p));

            return ((p1 - p) * line[0].Value + (p - p0) * line[1].Value) / (p1 - p0);
        }

        /// <summary>
        /// Interpolate the points bilinearly.
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static double Interpolate(Sample[,] samples, int x, int y)
        {
            if (samples[0, 0].X != samples[1, 0].X || samples[0, 1].X != samples[1, 1].X
                || samples[0, 0].Y != samples[0, 1].Y || samples[1, 0].Y != samples[1, 1].Y)
                throw new ArgumentException("Sample points do not form a rectangle.", nameof(samples));

            if (samples[0, 0].X > samples[0,1].X || samples[0, 0].Y > samples[1,0].Y)
                throw new ArgumentException("Sample points are in wrong order.", nameof(samples));

            double[,] w = new double[2, 2];

            double y0 = samples[0, 0].Y, y1 = samples[1, 0].Y;
            double x0 = samples[0, 0].X, x1 = samples[0, 1].X;
            

            double dx = x1 - x0, dy = y1 - y0, dxdy = dx * dy, dy1 = y1 - y, dy0 = y - y0, dx1 = x1 - x, dx0 = x - x0;

            w[0, 0] = dx1 * dy1;
            w[1, 0] = dx1 * dy0;
            w[0, 1] = dx0 * dy1;
            w[1, 1] = dx0 * dy0;

            double value = (w[0, 0] * samples[0, 0].Value + w[0, 1] * samples[0, 1].Value + w[1, 0] * samples[1, 0].Value + w[1, 1] * samples[1, 1].Value) / dxdy;

            return value;
        }
    }
}