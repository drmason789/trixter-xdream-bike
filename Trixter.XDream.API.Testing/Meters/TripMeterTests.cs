using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trixter.XDream.API.Flywheel;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Testing.Meters
{
    [TestFixture]
    public class TripMeterTests
    {
        [Test(Description = "A regression test that uses real data, obtained from a real X-Dream bike, with a real person pedalling, pushing buttons and pulling levers.")]
        public void KeepingItReal()
        {
            var inputMessages = XDreamMessageIO.Read(Resources.flywheel_crank_messages).AsMonotonic().ToArray();
         
            this.TestTripMeter(XDreamBikeFactory.CreatePremium,inputMessages, 19, 243, 130);
        }
        
        [Test]
        public void TestTripMeter()
        {
            var cadenceData = CrankMeterTests.GenerateCadenceData(100, 12, 120000, DateTimeOffset.UtcNow, MappedCrankMeter.DefaultMappingRawToRpm, x=>600000/500);

            IFlywheelMeter fwm = new MappedFlywheelMeter();
            ICrankMeter cm = new HybridCrankMeter();
            IPowerMeter pm = new PowerMeter(XDreamFlywheel.Default.MomentOfInertia);
            

            this.TestTripMeter(xtc=>new XDreamBike(xtc, fwm, cm, pm), cadenceData, 200, 960, 1320);

        }

        private void TestTripMeter(Func<XDreamClient, XDreamMachine> factory, XDreamState[] inputMessages, double expectedCrankRevolutions, double expectedFlywheelRevolutions, double expectedEnergy)
        {
            

            XDreamTestClient xtc = new XDreamTestClient();
            XDreamMachine xdm = factory(xtc);

            var statistics = new Experimental.StandardDeviationCalculator();
            DateTimeOffset last = DateTimeOffset.MinValue, t0 = inputMessages[0].TimeStamp;
            List<string> logs = new List<string>(inputMessages.Length);

            var (cm, fwm, pm) = (xdm.CrankMeter, xdm.FlywheelMeter, xdm.FlywheelPowerMeter);
            
            long lastProcessed = 0;

            xdm.StateUpdated += (s, m) =>
            {
                Interlocked.Exchange(ref lastProcessed, m.TimeStamp.Ticks);

                if (last != DateTimeOffset.MinValue)
                {
                    double dt = (m.TimeStamp - last).TotalMilliseconds;
                    statistics.Add(dt);

                    logs.Add($"{(m.TimeStamp - t0).TotalMilliseconds},{(cm.HasData ? cm.Direction : CrankDirection.None)},{(cm.HasData ? cm.RPM : 0)},{fwm.RPM},{pm.Power}, {m.Crank}, {m.CrankPosition}");
                }
                last = m.TimeStamp;
            };

            xtc.UpdateState(inputMessages);

            // Wait for the asynchronous message processing to catch up.
            long lastTimestamp = inputMessages.Last().TimeStamp.Ticks;
            while (Interlocked.Read(ref lastProcessed) < lastTimestamp)
                Thread.Sleep(100);

            System.Console.WriteLine($"Total time                                : {statistics.Sum}ms");
            System.Console.WriteLine($"Mean time between samples                 : {statistics.Mean}ms");
            System.Console.WriteLine($"Standard Deviation of time between samples: {statistics.StandardDeviation}ms");

            System.Console.WriteLine();
            System.Console.WriteLine("T,CrankDirection,CrankRPM,FlywheelRPM,Power,Crank,CrankPosition");
            System.Console.WriteLine(String.Join("\r\n", logs));


            Assert.That(Math.Round(xdm.TripMeter.CrankRevolutions, 0, MidpointRounding.AwayFromZero), Is.EqualTo(expectedCrankRevolutions));
            Assert.That(Math.Round(xdm.TripMeter.FlywheelRevolutions, 0, MidpointRounding.AwayFromZero), Is.EqualTo(expectedFlywheelRevolutions));

            // It's not certain if this is actually an accurate energy calculation, it's just a regression test.
            Assert.That(Math.Round(xdm.TripMeter.Energy, 0, MidpointRounding.AwayFromZero), Is.EqualTo(expectedEnergy));
        }
    }
}
