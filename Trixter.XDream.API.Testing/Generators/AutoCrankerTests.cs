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

            void assertNotFired() { Assert.That(changedEventDelta, Is.Null, nameof(ICadenceProvider.CrankPositionChanged) + " event should not have fired."); };
            void assertFired(int delta) 
            {
                Assert.That(changedEventDelta, Is.EqualTo(delta), nameof(ICadenceProvider.CrankPositionChanged) + $" event should have fired with delta={delta}.");
                changedEventDelta = null;
            };

            c.CrankPositionChanged += (s, d) => changedEventDelta = d;

            // Test that the RPM starts off as 0.
            Assert.That(c.RPM, Is.EqualTo(0));
            Assert.That(c.MillisecondsPerPosition, Is.EqualTo(double.PositiveInfinity));

            // Test setting the RPM to 1 then 0
            c.RPM = 1;
            Assert.That(c.RPM, Is.EqualTo(1));
            Assert.That(c.MillisecondsPerPosition, Is.EqualTo(1000));
            c.RPM = 0;
            Assert.That(c.RPM, Is.EqualTo(0));
            Assert.That(c.MillisecondsPerPosition, Is.EqualTo(double.PositiveInfinity));

            c.Update(t = t.AddMilliseconds(10));
            Assert.That(c.RPM, Is.EqualTo(0));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition));
            assertNotFired();

            // Test a full crank revolutiuon
            c.Update(t = t.AddMilliseconds(CrankPositions.Positions*millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(0));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition));
            assertNotFired();

            c.RPM = rpm1;
            Assert.That(c.RPM, Is.EqualTo(rpm1));
            Assert.That(c.MillisecondsPerPosition, Is.EqualTo(millisecondsPerPosition));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition));
            assertNotFired();
                        
            // Perform a full revolution
            c.Update(t = t.AddMilliseconds(CrankPositions.Positions * millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(rpm1));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition));
            assertFired(60);

            // Perform a single position movement
            c.Update(t = t.AddMilliseconds(millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(rpm1));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition + 1));
            assertFired(1);

            // Perform a 3 position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(3* millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(rpm1));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition + 3));
            assertFired(3);

            // Perform a 0.5 position movement, then a 1 position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(0.5* millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(rpm1));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition));
            assertNotFired();
            c.Update(t = t.AddMilliseconds(millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(rpm1));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition + 1));
            assertFired(1);

            // Change the RPM
            c.RPM = rpm2;
            Assert.That(c.RPM, Is.EqualTo(rpm2));
            millisecondsPerPosition = (double)Constants.MillisecondsPerMinute / (CrankPositions.Positions * rpm2);
            Assert.That(c.MillisecondsPerPosition, Is.EqualTo(millisecondsPerPosition));

            // Perform a single position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(rpm2));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition + 1));
            assertFired(1);

            // Perform a 3 position movement
            referencePosition = c.CrankPosition;
            c.Update(t = t.AddMilliseconds(3 * millisecondsPerPosition));
            Assert.That(c.RPM, Is.EqualTo(rpm2));
            Assert.That(c.CrankPosition, Is.EqualTo(referencePosition + 3));
            assertFired(3);

        }

        [Test]
        public void TestExceptions()
        {
            ICadenceProvider c = new AutoCranker();

            Assert.Throws<ArgumentOutOfRangeException>(() => { c.CrankPosition = CrankPositions.MinCrankPosition - 1; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { c.CrankPosition = CrankPositions.MaxCrankPosition + 1; });
            Assert.DoesNotThrow(() => { c.CrankPosition = CrankPositions.MaxCrankPosition; });
            Assert.DoesNotThrow(() => { c.CrankPosition = CrankPositions.MinCrankPosition; });
            Assert.Throws<ArgumentOutOfRangeException>(() => c.RPM = -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => c.RPM = AutoCranker.MaxRPM + 1);
            Assert.DoesNotThrow(() => c.RPM = 0);
            Assert.DoesNotThrow(() => c.RPM = AutoCranker.MaxRPM);
        }

    }
}
