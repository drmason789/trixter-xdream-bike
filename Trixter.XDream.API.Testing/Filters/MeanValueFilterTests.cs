using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trixter.XDream.API.Filters;
using Trixter.XDream.API.Testing.Experimental;

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
            Assert.That(mvf.Period, Is.EqualTo(300));
            Assert.That(mvf.Value, Is.EqualTo((2 + 3) / 2d).Within(tolerance));

        }


        [Test]
        public void TestMeanValueFilter_SplitOnSampleBoundary()
        {
            MeanValueFilter mvf = new MeanValueFilter(300);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));

            Assert.That(mvf.Period, Is.EqualTo(300));

            // The period is 300, so the first sample should not be included.
            double expected = 3;
            Assert.That(mvf.Value, Is.EqualTo(expected).Within(tolerance));
        }

        [Test]
        public void TestWeightedMeanValueFilter_SplitMidSample()
        {
            WeightedMeanValueFilter mvf = new WeightedMeanValueFilter(500);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));

            Assert.That(mvf.Period, Is.EqualTo(500));

            // Now that 500ms has been chopped off the end, we should have 200ms of sample 2 and 300ms of sample 3.
            double[] expectedSampleValues = new[] { 3d, 2d };
            double expected = (expectedSampleValues[0]*300d + expectedSampleValues[1] * 200d) / 500;
            Assert.That(mvf.Value, Is.EqualTo(expected).Within(tolerance));
        }

        [Test]
        public void TestWeightedMeanValueFilter_VariedTimestamps()
        {
            WeightedMeanValueFilter mvf = new WeightedMeanValueFilter(300);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(350));
            mvf.Add(4, t0.AddMilliseconds(500));
            
            Assert.That(mvf.Period, Is.EqualTo(300));

            // Now that 300ms has been chopped off the end, we should have 100ms of sample 2, 50ms of sample 3 and 150ms of sample 4.
            double[] expectedSampleValues = new[] { 4d, 3d, 2d };
            double expected = (expectedSampleValues[0] * 150d + expectedSampleValues[1] * 50d + expectedSampleValues[2]*100) / 300;
            Assert.That(mvf.Value, Is.EqualTo(expected).Within(tolerance));
        }

        [Test]
        public void TestWeightedMeanValueFilter_SplitOnSampleBoundary()
        {
            WeightedMeanValueFilter mvf = new WeightedMeanValueFilter(300);

            DateTimeOffset t0 = DateTimeOffset.Now;

            mvf.Add(1, t0);
            mvf.Add(2, t0.AddMilliseconds(300));
            mvf.Add(3, t0.AddMilliseconds(600));

            Assert.That(mvf.Period, Is.EqualTo(300));

            // The period is 300, so the first sample should not be included.
            double expected = 3;
            Assert.That(mvf.Value, Is.EqualTo(expected).Within(tolerance));
        }


        [Test(Description = "Regression test of value and delta")]
        [TestCase(typeof(MeanValueFilter), 1000,  0.48731523691519363d, -0.00092576070850890169d)]
        
        [TestCase(typeof(WeightedMeanValueFilter), 1000, 0.48929200066319867d, 0.0040764197120790905d)]
        
        public void SpeedTest(Type type, int period, double expected, double expectedDelta)
        {
            const int iterations = 1000000;

            Random random = new Random(10);
            DateTimeOffset t = DateTimeOffset.Now;
            MeanValueFilterBase mvf = (MeanValueFilterBase)Activator.CreateInstance(type, new object[] { period });
            double[] dT = Enumerable.Range(0, iterations).Select(x => random.NextDouble() * 10 + 1).ToArray();
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
            Assert.That(mvf.Value, Is.EqualTo(expected), "Value unexpected");
            Assert.That(mvf.Delta, Is.EqualTo(expectedDelta), "Delta unexpected");
        }

        
        [Test(Description = "Test that timestamps that do not increase monotonically are rejected.")]
        [TestCase(typeof(MeanValueFilter))]
        [TestCase(typeof(WeightedMeanValueFilter))]
        public void IncreasingTimeTest(Type type)
        {
            const int period = 500;
            const string shouldIncrease = "Filter should throw if the timestamp does not increase monotonically.";

            MeanValueFilterBase mvf = (MeanValueFilterBase)Activator.CreateInstance(type, new object[] { period });
            DateTimeOffset t = DateTimeOffset.Now;

            mvf.Add(1, t);
            t = t.AddMilliseconds(1);
            mvf.Add(2, t);

            Assert.Throws<ArgumentException>(() => mvf.Add(3, t), shouldIncrease);
            t = t.AddMilliseconds(-1);
            Assert.Throws<ArgumentException>(() => mvf.Add(3, t), shouldIncrease);

        }
    }
}
