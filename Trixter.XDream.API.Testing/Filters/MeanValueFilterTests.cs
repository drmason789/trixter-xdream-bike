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
        public void TestMeanValueFilter_SplitMidSample()
        {
            MeanValueFilter mvf = new MeanValueFilter(500);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));

            // Not looking for 500 here because this filter doesn't split samples at the cutoff point.
            Assert.AreEqual(300, mvf.Period);
            Assert.AreEqual((2 + 3) / 2d, mvf.Value, tolerance);
        }


        [Test]
        public void TestMeanValueFilter_SplitOnSampleBoundary()
        {
            MeanValueFilter mvf = new MeanValueFilter(300);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));
                        
            Assert.AreEqual(300, mvf.Period);
            Assert.AreEqual(3, mvf.Value, tolerance);
        }

        [Test]
        public void TestWeightedMeanValueFilter_SplitMidSample()
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
        public void TestWeightedMeanValueFilter_SplitOnSampleBoundary()
        {
            WeightedMeanValueFilter mvf = new WeightedMeanValueFilter(300);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));

            Assert.AreEqual(300, mvf.Period);
            Assert.AreEqual(3, mvf.Value, tolerance);
        }


        [Test]
        [TestCase(typeof(MeanValueFilter), 1000, 0.48544358988983127d, -0.0015909654334074566d)]
        [TestCase(typeof(WeightedMeanValueFilter), 1000, 0.48562740929878312d, 0.0078560187173342937d)]
        public void SpeedTest(Type type, int period, double expected, double expectedDelta)
        {
            const int iterations = 1000000;

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
            Assert.AreEqual(expectedDelta, mvf.Delta);
        }
    }
}
