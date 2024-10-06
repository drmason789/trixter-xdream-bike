using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Testing.Meters
{

    [TestFixture]
    public class HybridCrankMeterTests
    {
        Func<int, int> rpmConverter = x => x <= 0 ? 0 : (x >= 65534 ? 0 : (int)(1.0d / (6.1e-6)) / x);

        /// <summary>
        /// Tests for expected RPM and direction when sample cadence data crosses the transition threshold for a <see cref="HybridCrankMeter"/>.
        /// </summary>
        [Test]
        public void TestHybrid()
        {
            // RPM from raw value calculator - different from the default to test this is the one used.
            
            
            TestTransition(new HybridCrankMeter(rpmConverter), 4, rpmConverter);
        }

        /// <summary>
        /// Generate comparison data from a <see cref="PositionalCrankMeter"/> for a <see cref="HybridCrankMeter"/>.
        /// </summary>
        [Test]
        public void TestPositional() => TestTransition(new PositionalCrankMeter(1100),4, rpmConverter);


        private void TestTransition(ICrankMeter cc, int tolerance, Func<int,int> rpmToRaw)
        {
            const int sampleIntervalMilliseconds = 10;
            List<XDreamState> allStates = new List<XDreamState>();
            List<int> expectedRPMs = new List<int>();
            DateTimeOffset t0 = DateTimeOffset.UtcNow;
            int transitionIndex = 0;
            List<String> mismatches = new List<string>();
                       
            for(int rpm=15; rpm<=HybridCrankMeter.PositionalUpperLimitRPM+100; rpm++)
            {
                var states = CrankMeterTests.GenerateCadenceData(rpm, sampleIntervalMilliseconds, 2000, t0, rpmToRaw, x=>65534);

                allStates.AddRange(states);
                expectedRPMs.AddRange(Enumerable.Range(0, states.Length).Select(x=>rpm));
                t0 = states.Last().TimeStamp.AddMilliseconds(sampleIntervalMilliseconds);

                if(rpm==HybridCrankMeter.PositionalUpperLimitRPM)
                    transitionIndex = allStates.Count;
                
                Array.ForEach(states,cc.AddData);

                int actualDirectionalRPM = cc.Direction == CrankDirection.Backward ? -cc.RPM : cc.RPM;                

                if (Math.Abs(rpm-actualDirectionalRPM)>tolerance)
                    mismatches.Add($"Actual: {actualDirectionalRPM}RPM vs Expected: {rpm}RPM");
            }

            Assert.That(mismatches.Count, Is.EqualTo(0), string.Join("\r\n", mismatches));
            
        }
    }
}
