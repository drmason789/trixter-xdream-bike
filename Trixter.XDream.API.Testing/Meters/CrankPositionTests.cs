using NUnit.Framework;

namespace Trixter.XDream.API.Testing.Meters
{
    [TestFixture]
    public class CrankPositionTests
    {
        [Test]
        [TestCase(1,1,2)]
        [TestCase(1,-1,60)]
        [TestCase(1, -2, 59)]
        [TestCase(1, 60, 1)]
        [TestCase(1, -60, 1)]
        [TestCase(1, 121, 2)]
        [TestCase(1, -122, 59)]
        [TestCase(60, 1, 1)]
        [TestCase(60, 2, 2)]
        [TestCase(60, 120, 60)]
        [TestCase(60, 121, 1)]

        public void TestAdd(int position, int delta, int expected)
        {
            int actual = CrankPositions.Add(position, delta);
            Assert.AreEqual(expected, actual);
        }
    }

}
