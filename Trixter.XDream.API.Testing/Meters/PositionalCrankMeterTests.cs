using NUnit.Framework;
using System;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Testing.Meters
{
    [TestFixture]
    public class PositionalCrankMeterTests
    {
        /// <summary>
        /// Test that an object of the <see cref="PositionalCrankMeter"/> class will correctly detect the expected direction and RPM between 2 samples.
        /// Assumes the direction calculated will be the direction of shortest distance between the positions.
        /// </summary>
        /// <param name="position0"></param>
        /// <param name="position1"></param>
        /// <param name="expectedDirection"></param>
        [TestCase(10, 50, CrankDirection.Backward)]
        [TestCase(1, 60, CrankDirection.Backward)]
        [TestCase(50, 10, CrankDirection.Forward)]
        [TestCase(60, 1, CrankDirection.Forward)]
        [TestCase(1, 1, CrankDirection.None)]
        public void TestDirectionAndRPM_2Samples(int position0, int position1, CrankDirection expectedDirection)
        {
            ICrankMeter cs = new PositionalCrankMeter();

            double dt = 100d;
            DateTimeOffset t0 = DateTimeOffset.UtcNow, t1 = t0.AddMilliseconds(dt);

            cs.AddData(t0, position0, 0);
            cs.AddData(t1, position1, 0);

            Assert.AreEqual(expectedDirection, cs.Direction);

            if (cs.Direction == CrankDirection.None)
            {
                Assert.AreEqual(0, cs.RPM);
            }
            else
            {
                int dp = 0;
                
                // Now calculate the positional RPM
                if (cs.Direction == CrankDirection.Backward)
                    dp = CrankPositions.CrankDelta(position1, position0);
                else
                    dp = CrankPositions.CrankDelta(position0, position1);

                double notchesPerMillisecond = dp / dt;
                double notchesPerMinute = Constants.MillisecondsPerMinute * notchesPerMillisecond;
                int rpm = (int)(0.5 + CrankPositions.RevolutionsPerPosition * notchesPerMinute);

                Assert.AreEqual(rpm, cs.RPM, "Expected RPM");
            }
        }

        /// <summary>
        /// Test that the position and time values result in the expected RPM. 
        /// This is can be affected by <see cref="PositionalCrankMeter.SmoothingIntervalMilliseconds"/>.
        /// </summary>
        /// <param name="positions">Crank positions</param>
        /// <param name="t">Time in milliseconds of crank position readings in <see cref="positions"/></param>
        /// <param name="expectedRPM">The RPM expected </param>
        [Test]
        [TestCase(new int[] { 1, 2, 3,3,3,3 }, new[] {0, 300, 600, 900, 1200,1500 }, 0, 500, TestName ="Stopping")]
        [TestCase(new int[] { 1, 60, 59 }, new[] { 0, 100, 200 }, 10, 500, TestName = "Backwards")]
        [TestCase(new int[] { 1, 2 }, new[] { 100, 200 }, 1000 / 100, 500)]
        [TestCase(new int[] { 1, 2, 3 }, new[] { 100, 200, 250 }, 13, 500)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 2 }, new[] { 0, 100, 200, 300, 400, 500 }, 1000 / 500, 500)]
        [TestCase(new int[] { 60, 60, 60, 60, 1, 1, 1, 1, 1, 2 }, 
                       new[] { 0, 100, 200, 300, 400, 500, 600, 700, 800, 900 }, 4, 500)]
        public void TestSpeed(int[] positions, int[] t, int expectedRPM, int smoothingIntervalMilliseconds)
        {
            Assert.AreEqual(positions.Length, t.Length, "Position and time arrays should be the same length.");

            ICrankMeter cs = new PositionalCrankMeter(smoothingIntervalMilliseconds);

            for (int i = 0; i < CrankPositions.Positions; i++)
            {
                DateTimeOffset t0 = DateTimeOffset.UtcNow;

                cs.Reset();

                for (int sample = 0; sample < positions.Length; sample++)
                {
                    int p = CrankPositions.Add(positions[sample], i);
                    cs.AddData(t0.AddMilliseconds(t[sample]), p, 0);
                }

                Assert.AreEqual(expectedRPM, cs.RPM, $"Expected RPM failed when positions offset by {i}");
            }

        }


        /// <summary>
        /// Generates test data for the specified RPM and direction and tests that the calculated RPM is within the specified tolerance.
        /// </summary>
        /// <param name="rpm">Target RPM - use a negative number for backward cadence.</param>
        /// <param name="smoothingInterval">The smoothing interval, in milliseconds, for the <see cref="PositionalCrankMeter"/> object.</param>
        /// <param name="tolerance"></param>
        [Test]
        [TestCase(100, 500,4)]
        [TestCase(-100, 500,4)]
        [TestCase(60,  500,4)]
        [TestCase(-60,  500,4)]
        [TestCase(120,  500,4)]
        [TestCase(-120,  500,4)]
        [TestCase(180, 1000,4)]
        [TestCase(-180,  500,4)]
        [TestCase(300,  500,6)]
        [TestCase(-300,  500,6)]
        [TestCase(-1, 1100,0)]
        [TestCase(1,1100,0)]
        [TestCase(0, 2000,4)]
        public void TestDirectionAndRPM(int rpm,  int smoothingInterval, int tolerance)
        {
            PositionalCrankMeter cs = new PositionalCrankMeter(smoothingInterval);
            var expectedDirection = CrankPositions.GetDirection(rpm);
            int directionalRpm = Math.Abs(rpm);
            XDreamState[] cadenceData = CrankMeterTests.GenerateCadenceData(rpm, 10, 2*smoothingInterval, DateTimeOffset.UtcNow, MappedCrankMeter.DefaultMappingRawToRpm, x=>65534);

            Array.ForEach(cadenceData, cs.AddData);

            Assert.AreEqual(expectedDirection, cs.Direction);
            Assert.LessOrEqual(Math.Abs(cs.RPM-directionalRpm), tolerance, "Calculated RPM is not within expected tolerance.");

        }
    }

}
