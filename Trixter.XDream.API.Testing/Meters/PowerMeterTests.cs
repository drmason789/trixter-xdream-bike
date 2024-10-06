using NUnit.Framework;
using System;
using Trixter.XDream.API.Flywheel;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Testing.Meters
{
    [TestFixture(typeof(EnergyPowerMeter))]
    [TestFixture(typeof(PowerMeter))]
    public class PowerMeterTests
    {

        readonly Func<double, IPowerMeter> createPowerMeter;

        protected IPowerMeter CreatePowerMeter(double momentOfInertia)
        {
            return this.createPowerMeter(momentOfInertia);
        }

        public PowerMeterTests(Type meterType)
        {
            var constructor = meterType.GetConstructor(new Type[] { typeof(double) });
            createPowerMeter = I => (IPowerMeter)constructor.Invoke(new object[] { I });
        }


        [Test]
        [TestCase(10, new int[] {}, new int[] {  }, 0)]
        [TestCase(10, new int[] { 1000 }, new int[] { 0 }, 0)]
        [TestCase(10, new int[] { 1000, 1 }, new int[] { 0, 1000 }, 0)]
        [TestCase(10, new int[] { 1,2 }, new int[] { 0, 1000 },0)]
        [TestCase(10, new int[] { 180, 181 }, new int[] { 0, 1000 }, 20)]
        [TestCase(10, new int[] { 1, 2,3,4,5,6,7,8,9,10 }, new int[] { 0, 100, 200,300,400,500,600,700,800,900 }, 2)]
        public void TestPowerMeter(double momentOfInertia, int [] rpms, int [] sampleTimes, int expectedWatts)
        {
            if(rpms==null) throw new ArgumentNullException(nameof(rpms));
            if(sampleTimes==null) throw new ArgumentNullException(nameof(sampleTimes));
            if(rpms.Length != sampleTimes.Length) throw new ArgumentException("The same number of sample RPMs and times must be provided.");

            IPowerMeter powerMeter = this.CreatePowerMeter(momentOfInertia);

            DateTimeOffset t = DateTimeOffset.UtcNow;

            for(int i=0; i<rpms.Length; i++)
            {
                t = t.AddMilliseconds(sampleTimes[i]);
                powerMeter.Update(t, rpms[i]*Constants.RpmToRadiansPerSecond);
            }

            Assert.That(powerMeter.Power, Is.EqualTo(expectedWatts));

        }
                
    }
}
