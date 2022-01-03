using NUnit.Framework;
using Trixter.XDream.API.Flywheel;

namespace Trixter.XDream.API.Testing
{
    [TestFixture(Description ="Tests specifically for the X-Dream V1 flywheel model")]
    public class XDreamFlywheelTests
    {

        [Test]
        public void TestDefaultXDreamFlywheel()
        {
            var flywheel = XDreamFlywheel.Default;

            // 15kg is a vague memory of a measurement from an uninstalled flywheel. It's possibly closer to 14.8kg
            Assert.AreEqual(15.0d, flywheel.Mass, "Unexpected mass. Check section density.");

            // 220mm is an approximate measurement with the flywheel installed on the bike.
            Assert.AreEqual(220, flywheel.Radius, "Flywheel radius");

            // This is a regression test value. Correctness unknown.
            Assert.AreEqual(0.41187783076277362d, flywheel.MomentOfInertia, "Moment of Inertia");
        }
    }
}
