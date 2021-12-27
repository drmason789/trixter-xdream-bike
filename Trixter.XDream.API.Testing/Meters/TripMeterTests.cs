using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class TripMeterTests
    {
        [Test(Description = "A test that uses real data, obtained from a real X-Dream bike, with a real person pedalling, pushing buttons and pulling levers.")]
        public void KeepingItReal()
        {
            IFlywheelMeter fwm = new MappedFlywheelMeter();
            ICrankMeter cm = new HybridCrankMeter();
            ITripMeter tm = new TripMeter(fwm, cm);

            var inputMessages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);
            var statistics = new Experiments.Statistics();
            DateTimeOffset last = DateTimeOffset.MinValue, t0=inputMessages[0].TimeStamp;
            List<string> logs = new List<string>(inputMessages.Length);

            Array.ForEach(inputMessages,
                m =>
                {
                    fwm.AddData(m);
                    cm.AddData(m);
                    tm.Update(m.TimeStamp);
                
                    if(last!=DateTimeOffset.MinValue)
                    {
                        double dt = (m.TimeStamp - last).TotalMilliseconds;
                        statistics += dt;

                        logs.Add($"{(m.TimeStamp-t0).TotalMilliseconds},{(cm.HasData ? cm.Direction : CrankDirection.None)},{(cm.HasData ? cm.RPM : 0)},{fwm.RPM}");
                    }
                    last = m.TimeStamp;

                });

            System.Console.WriteLine($"Total time                                : {statistics.Sum}ms");
            System.Console.WriteLine($"Mean time between samples                 : {statistics.Mean}ms");
            System.Console.WriteLine($"Standard Deviation of time between samples: {statistics.StandardDeviation}ms");

            System.Console.WriteLine();
            System.Console.WriteLine("T,CrankDirection,CrankRPM,FlywheelRPM");
            System.Console.WriteLine(String.Join("\r\n", logs));


            Assert.AreEqual(19, Math.Round(tm.CrankRevolutions, 0, MidpointRounding.AwayFromZero));
            Assert.AreEqual(253, Math.Round(tm.FlywheelRevolutions,0,MidpointRounding.AwayFromZero));
        }

        [Test]
        public void TestTripMeter()
        {
            var cadenceData = CrankMeterTests.GenerateCadenceData(100, 12, 120000, DateTimeOffset.UtcNow, MappedCrankMeter.DefaultMappingRawToRpm, x=>600000/500);

            XDreamTestClient tc = new XDreamTestClient();
            IFlywheelMeter fwm = new MappedFlywheelMeter();
            ICrankMeter cm = new HybridCrankMeter();
            XDreamMachine m = new XDreamBike(tc, fwm, cm);

            ITripMeter tm = new TripMeter(fwm, cm);

            m.StateUpdated += (s, e) => tm.Update(e.TimeStamp);

            tc.UpdateState(cadenceData);

            // Wait for the asynchronous message processing to catch up.
            Thread.Sleep(1000);

            Assert.AreEqual(199.98, tm.CrankRevolutions);
            Assert.AreEqual(999.9, tm.FlywheelRevolutions);

        }
    }
}
