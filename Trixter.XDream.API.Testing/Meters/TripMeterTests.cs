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
            IFlywheelMeter fwm = new MappedFlywheelMeter();
            ICrankMeter cm = new HybridCrankMeter();
            IPowerMeter pm = new PowerMeter(XDreamFlywheel.Default.MomentOfInertia);
            ITripMeter tm = new TripMeter(fwm, cm, pm);

            var inputMessages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);
            var statistics = new Experimental.StandardDeviationCalculator();
            DateTimeOffset last = DateTimeOffset.MinValue, t0=inputMessages[0].TimeStamp;
            List<string> logs = new List<string>(inputMessages.Length);

            Array.ForEach(inputMessages,
                m =>
                {
                    fwm.AddData(m);
                    cm.AddData(m);
                    pm.Update(m.TimeStamp, fwm.AngularVelocity);
                    tm.Update(m.TimeStamp);
                
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


            Assert.AreEqual(19, Math.Round(tm.CrankRevolutions, 0, MidpointRounding.AwayFromZero));
            Assert.AreEqual(243, Math.Round(tm.FlywheelRevolutions,0,MidpointRounding.AwayFromZero));

            // It's not certain if this is actually an accurate power calculation, it's just a regression test.
            Assert.AreEqual(1218, Math.Round(tm.Power, 0, MidpointRounding.AwayFromZero));
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

            Assert.AreEqual((double)199.98, (double)tm.CrankRevolutions, tolerance);
            Assert.AreEqual((double)959.904m, (double)tm.FlywheelRevolutions, tolerance);

            // This was constant speed, and current system doesn't account for friction or
            // other forces that might slow the wheel. So expect 0 power applied.
            Assert.AreEqual(0m, tm.Power);

        }
    }
}
