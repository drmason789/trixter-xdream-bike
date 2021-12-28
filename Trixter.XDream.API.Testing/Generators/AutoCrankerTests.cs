using NUnit.Framework;
using System;
using Trixter.XDream.API.Generators;

namespace Trixter.XDream.API.Testing.Generators
{
    [TestFixture]
    public class AutoCrankerTests
    {
        [Test]
        [TestCase(60,65)]
        [TestCase(1,20)]
        [TestCase(100, 150)]
        [TestCase(500,1000)]
        public void TestMovement(int rpm1, int rpm2)
        {
            ICadenceProvider c = new AutoCranker();
            DateTimeOffset t = DateTimeOffset.UtcNow;
            int? changedEventDelta = null;
            int referencePosition = c.CrankPosition;
            double millisecondsPerPosition = (double)Constants.MillisecondsPerMinute / (CrankPositions.Positions * rpm1);

            void assertNotFired() { Assert.IsNull(changedEventDelta, nameof(ICadenceProvider.CrankPositionChanged) + " event should not have fired."); };
            void assertFired(int delta) 
            {
                Assert.AreEqual(delta, changedEventDelta, nameof(ICadenceProvider.CrankPositionChanged) + $" event should have fired with delta={delta}.");
                changedEventDelta = null;
            };

            c.CrankPositionChanged += (s, d) => changedEventDelta = d;

            // Test that the RPM starts off as 0.
            Assert.AreEqual(0, c.RPM);
            Assert.AreEqual(double.PositiveInfinity, c.MillisecondsPerPosition);

            // Test setting the RPM to 1 then 0
            c.RPM = 1;
            Assert.AreEqual(1, c.RPM);
            Assert.AreEqual(1000, c.MillisecondsPerPosition);
            c.RPM = 0;
            Assert.AreEqual(0, c.RPM);
            Assert.AreEqual(double.PositiveInfinity, c.MillisecondsPerPosition);

            c.Update(t = t.AddMilliseconds(10));
            Assert.AreEqual(0, c.RPM);
            Assert.AreEqual(referencePosition, c.CrankPosition);
            assertNotFired();

            // Test a full crank revolutiuon
            c.Update(t = t.AddMilliseconds(CrankPositions.Positions*millisecondsPerPosition));
            Assert.AreEqual(0, c.RPM);
            Assert.AreEqual(referencePosition, c.CrankPosition);
            assertNotFired();

            c.RPM = rpm1;
            Assert.AreEqual(rpm1, c.RPM);
            Assert.AreEqual(millisecondsPerPosition, c.MillisecondsPerPosition);
            Assert.AreEqual(referencePosition, c.CrankPosition);
            assertNotFired();
                        
            // Perform a full revolution
            c.Update(t = t.AddMilliseconds(CrankPositions.Positions * millisecondsPerPosition));
            Assert.AreEqual(rpm1, c.RPM);
            Assert.AreEqual(referencePosition, c.CrankPosition);
            assertFired(60);

            // Perform a single position movement
            c.Update(t = t.AddMilliseconds(millisecondsPerPosition));
            Assert.AreEqual(rpm1, c.RPM);
            Assert.AreEqual(referencePosition+1, c.CrankPosition);
            assertFired(1);

            // Perform a 3 position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(3* millisecondsPerPosition));
            Assert.AreEqual(rpm1, c.RPM);
            Assert.AreEqual(referencePosition + 3, c.CrankPosition);
            assertFired(3);

            // Perform a 0.5 position movement, then a 1 position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(0.5* millisecondsPerPosition));
            Assert.AreEqual(rpm1, c.RPM);
            Assert.AreEqual(referencePosition, c.CrankPosition);
            assertNotFired();
            c.Update(t = t.AddMilliseconds(millisecondsPerPosition));
            Assert.AreEqual(rpm1, c.RPM);
            Assert.AreEqual(referencePosition+1, c.CrankPosition);
            assertFired(1);

            // Change the RPM
            c.RPM = rpm2;
            Assert.AreEqual(rpm2, c.RPM);
            millisecondsPerPosition = (double)Constants.MillisecondsPerMinute / (CrankPositions.Positions * rpm2);
            Assert.AreEqual(millisecondsPerPosition, c.MillisecondsPerPosition);

            // Perform a single position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(millisecondsPerPosition));
            Assert.AreEqual(rpm2, c.RPM);
            Assert.AreEqual(referencePosition + 1, c.CrankPosition);
            assertFired(1);

            // Perform a 3 position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(3 * millisecondsPerPosition));
            Assert.AreEqual(rpm2, c.RPM);
            Assert.AreEqual(referencePosition + 3, c.CrankPosition);
            assertFired(3);

        }

        [Test]
        public void TestExceptions()
        {
            ICadenceProvider c = new AutoCranker();

            Assert.Throws<ArgumentOutOfRangeException>(() => { c.CrankPosition = CrankPositions.MinCrankPosition - 1; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { c.CrankPosition = CrankPositions.MaxCrankPosition + 1; });
            Assert.Throws<ArgumentOutOfRangeException>(() => c.RPM = -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => c.RPM = AutoCranker.MaxRPM);
        }

    }
}
