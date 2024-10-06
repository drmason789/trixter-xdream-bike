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
        const double tolerance = 0.0001;

        [Test(Description = "A regression test that uses real data, obtained from a real X-Dream bike, with a real person pedalling, pushing buttons and pulling levers.")]
        public void KeepingItReal()
        {
            XDreamTestClient xtc = new XDreamTestClient();
            XDreamMachine xdm = XDreamBikeFactory.CreatePremium(xtc);

            var inputMessages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);
            var statistics = new Experimental.StandardDeviationCalculator();
            DateTimeOffset last = DateTimeOffset.MinValue, t0=inputMessages[0].TimeStamp;
            List<string> logs = new List<string>(inputMessages.Length);

            var (cm, fwm, pm) = (xdm.CrankMeter, xdm.FlywheelMeter,xdm.FlywheelPowerMeter);

            Array.ForEach(inputMessages,
                m =>
                {
                    xtc.UpdateState(m);
                
                    if(last!=DateTimeOffset.MinValue)
                    {
                        double dt = (m.TimeStamp - last).TotalMilliseconds;
                        statistics.Add(dt);

                        logs.Add($"{(m.TimeStamp-t0).TotalMilliseconds},{(cm.HasData ? cm.Direction : CrankDirection.None)},{(cm.HasData ? cm.RPM : 0)},{fwm.RPM},{pm.Power}");
                    }
                    last = m.TimeStamp;

                });

            System.Console.WriteLine($"Total time                                : {statistics.Sum}ms");
            System.Console.WriteLine($"Mean time between samples                 : {statistics.Mean}ms");
            System.Console.WriteLine($"Standard Deviation of time between samples: {statistics.StandardDeviation}ms");

            System.Console.WriteLine();
            System.Console.WriteLine("T,CrankDirection,CrankRPM,FlywheelRPM,Power");
            System.Console.WriteLine(String.Join("\r\n", logs));


            Assert.That(Math.Round(xdm.TripMeter.CrankRevolutions, 0, MidpointRounding.AwayFromZero), Is.EqualTo(19));
            Assert.That(Math.Round(xdm.TripMeter.FlywheelRevolutions, 0, MidpointRounding.AwayFromZero), Is.EqualTo(243));

            // It's not certain if this is actually an accurate energy calculation, it's just a regression test.
            Assert.That(Math.Round(xdm.TripMeter.Energy, 0, MidpointRounding.AwayFromZero), Is.EqualTo(1254));
        }

        [Test]
        public void TestTripMeter()
        {
            var cadenceData = CrankMeterTests.GenerateCadenceData(100, 12, 120000, DateTimeOffset.UtcNow, MappedCrankMeter.DefaultMappingRawToRpm, x=>600000/500);
            
            XDreamTestClient tc = new XDreamTestClient();
            IFlywheelMeter fwm = new MappedFlywheelMeter();
            ICrankMeter cm = new HybridCrankMeter();
            IPowerMeter pm = new PowerMeter(XDreamFlywheel.Default.MomentOfInertia);
            XDreamMachine m = new XDreamBike(tc, fwm, cm, pm);

            ITripMeter tm = m.TripMeter;

            m.StateUpdated += (s, e) => tm.Update(e.TimeStamp);

            tc.UpdateState(cadenceData);

            // Wait for the asynchronous message processing to catch up.
            Thread.Sleep(1000);

            Assert.That((double)tm.CrankRevolutions, Is.EqualTo((double)199.98).Within(tolerance));
            Assert.That((double)tm.FlywheelRevolutions, Is.EqualTo((double)959.904m).Within(tolerance));

            // This is just a regression test, and the value comes from a calculation using the power table gleaned from an X-Dream configuration file.
            Assert.That(tm.Energy, Is.EqualTo(1319.868m));

        }
    }
}
