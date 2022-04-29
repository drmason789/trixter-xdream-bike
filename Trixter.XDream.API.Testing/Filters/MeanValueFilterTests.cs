using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trixter.XDream.API.Filters;

namespace Trixter.XDream.API.Testing.Filters
{
    [TestFixture]
    public class MeanValueFilterTests
    {
        const double tolerance = 1.0e-10;

        [Test]
        public void TestMeanValueFilter()
        {
            MeanValueFilter mvf = new MeanValueFilter(500);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));

            // Not looking for 500 here because this filter doesn't split samples at the cutoff point.
            Assert.AreEqual(300, mvf.Period);
        }

        [Test]
        public void TestWeightedMeanValueFilter()
        {
            WeightedMeanValueFilter mvf = new WeightedMeanValueFilter(500);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));

            Assert.AreEqual(500, mvf.Period);
            Assert.AreEqual((3d * 300d + 2d * 200d) / 500d, mvf.Value, tolerance);
        }


        [Test]
        [TestCase(typeof(MeanValueFilter), 1000, 0.5476129745983358d)]
        [TestCase(typeof(WeightedMeanValueFilter), 1000, 0.53976149111695693d)]
        public void SpeedTest(Type type, int period, double expected)
        {
            const int iterations = 100000;

            Random random = new Random(10);
            DateTimeOffset t = DateTimeOffset.Now;
            MeanValueFilterBase mvf = (MeanValueFilterBase)Activator.CreateInstance(type, new object[] { period });
            double[] dT = Enumerable.Range(0, iterations).Select(x => random.NextDouble() * 10 + 0.0001).ToArray();
            double[] v = Enumerable.Range(0, iterations).Select(x => random.NextDouble()).ToArray();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                t = t.AddMilliseconds(dT[i]);

                mvf.Add(v[i], t);
            }
            stopwatch.Stop();
            System.Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
            Assert.AreEqual(expected, mvf.Value);
        }
    }
}
