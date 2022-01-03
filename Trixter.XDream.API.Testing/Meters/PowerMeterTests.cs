using NUnit.Framework;
using System;
using Trixter.XDream.API.Flywheel;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class PowerMeterTests
    {
        [Test]
        [TestCase(10, new int[] {}, new int[] {  }, 0)]
        [TestCase(10, new int[] { 1000 }, new int[] { 0 }, 0)]
        [TestCase(10, new int[] { 1000, 1 }, new int[] { 0, 1000 }, 0)]
        [TestCase(10, new int[] { 1,2 }, new int[] { 0, 1000 }, 13)]
        [TestCase(10, new int[] { 180, 181 }, new int[] { 0, 1000 }, 1191)]
        [TestCase(10, new int[] { 1, 2,3,4,5,6,7,8,9,10 }, new int[] { 0, 100, 200,300,400,500,600,700,800,900 }, 146)]
        public void TestPowerMeter(double momentOfInertia, int [] rpms, int [] sampleTimes, int expectedWatts)
        {
            if(rpms==null) throw new ArgumentNullException(nameof(rpms));
            if(sampleTimes==null) throw new ArgumentNullException(nameof(sampleTimes));
            if(rpms.Length != sampleTimes.Length) throw new ArgumentException("The same number of sample RPMs and times must be provided.");

            IPowerMeter powerMeter = new PowerMeter(momentOfInertia);

            DateTimeOffset t = DateTimeOffset.UtcNow;

            for(int i=0; i<rpms.Length; i++)
            {
                t = t.AddMilliseconds(sampleTimes[i]);
                powerMeter.Update(t, rpms[i]);
            }

            Assert.AreEqual(expectedWatts, powerMeter.Power);

        }
    }
}
