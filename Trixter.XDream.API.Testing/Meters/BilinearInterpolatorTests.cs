using System;
using System.Drawing;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Testing.Meters
{
    [TestFixture]
    public class BilinearInterpolatorTests
    {
        /// <summary>
        /// Test for bilinear interpolation.
        /// </summary>
        /// <param name="minX">The origin X value.</param>
        /// <param name="incX">The increment in the X direction.</param>
        /// <param name="minY">The origin Y value.</param>
        /// <param name="incY">The increment in the Y direction.</param>
        /// <exception cref="ArgumentException"></exception>
       
        [Test]
        [TestCase(30,10,100,50)]
        [TestCase(100,50,30,10)]

        public void TestBilinearInterpolation(int minX, int incX, int minY,  int incY)
        {
            // To generate an internal point, this will use 1/4 of the increment
            if (incX < 4) throw new ArgumentException(nameof(incX));
            if (incY < 4) throw new ArgumentException(nameof(incY));
            Point partial = new Point(incX >> 2, incY >> 2);

            // utility to display a point in error messages
            Func<Point, string> pointString = p => $"({p.X},{p.Y})";

            // The function to sample.
            Func<int, int, double> getValue = (x, y) => x * y;

            // Crete a bilinear interpolator that is rooted at (minX,minY) and has 4 quadrants, i.e. dimensions are 2*the increment.
            BilinearInterpolator bi = new BilinearInterpolator(minX, minX+2*incX, incX, minY, minY+2*incY, incY, getValue);

            // For each quadrant
            for (int qy = 0; qy < 2; qy++)
                for (int qx = 0; qx < 2; qx++)
                {
                    // Create the corners. Values for these should not need to be interpolated.
                    Point[,] c = new Point[2, 2];
                    c[0, 0] = new Point(minX + qx * incX, minY + qy * incY);
                    c[0, 1] = new Point(c[0, 0].X, c[0, 0].Y + incY);
                    c[1, 1] = new Point(c[0, 0].X + incX, c[0, 0].Y + incY);
                    c[1, 0] = new Point(c[0, 0].X + incX, c[0, 0].Y);

                    // Error message text showing the quadrant
                    string quadrant = $"({c[0, 0].X}, {c[0, 0].Y})-({c[1, 1].X}, {c[1, 1].Y})";
                    
                    // A point inside the quadrant. This should trigger bilinear interpolation.
                    Point pi = new Point(c[0, 0].X + partial.X, c[0, 0].Y + partial.Y);

                    // A point on the X edge of the quadrant. This should be linearly interpolated
                    Point px = new Point(c[0, 0].X + partial.X, c[0, 0].Y);

                    // A point on the Y edge of the quadrant. This should be linearly interpolated.
                    Point py = new Point(c[0, 0].X, c[0, 0].Y + partial.Y);

                    for (int y = 0; y < 2; y++)
                        for (int x = 0; x < 2; x++)
                        {
                            Point corner = c[x, y];
                            double value = bi[corner.X, corner.Y];

                            Assert.AreEqual(getValue(corner.X, corner.Y), value, $"Corner {pointString(corner)} in " + quadrant);
                        }

                    Assert.AreEqual(getValue(pi.X, pi.Y), bi[pi.X, pi.Y], $"Internal point {pointString(pi)} in " + quadrant);
                    Assert.AreEqual(getValue(px.X, px.Y), bi[px.X, px.Y], $"Edge point {pointString(px)} in " + quadrant);
                    Assert.AreEqual(getValue(py.X, py.Y), bi[py.X, py.Y], $"Edge point {pointString(py)} in " + quadrant);
                }
        }
        

        //[Test]
        //public void GenerateGrids()
        //{
        //    Func<int, int, double> getPower = (c, r) => PowerTable.GetWattsFromRPM(c, r);

        //    StringBuilder result = new StringBuilder();
        //    result.AppendLine("RPM," + string.Join(",", Enumerable.Range(0, 251).Select(i => i.ToString())));

        //    for (int rpm = 30; rpm <= 120; rpm++)
        //    {
        //        result.Append(rpm.ToString());
        //        result.Append(",");

        //        result.AppendLine(string.Join(",",
        //            Enumerable.Range(0, 250).Select(i => getPower(rpm, i))));
        //    }

        //    System.Console.WriteLine(result.ToString());
        //}
    }
}