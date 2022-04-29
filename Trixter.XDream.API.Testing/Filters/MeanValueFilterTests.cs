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

        [Test(Description ="See how fast the filter is.")]
        [TestCase( 1000, 0.5476129745983358d)]        
        public void SpeedTest( int period, double expected)
        {
            const int iterations = 100000;
            Random random = new Random(10);
            DateTimeOffset t = DateTimeOffset.Now;
            MeanValueFilter mvf = new MeanValueFilter(period);
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
