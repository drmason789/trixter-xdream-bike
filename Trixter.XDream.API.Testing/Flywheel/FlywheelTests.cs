using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trixter.XDream.API.Flywheel;

namespace Trixter.XDream.API.Testing.Flywheel
{
    
    [TestFixture(Description ="General flywheel functionality tests")]
    public class FlywheelTests
    {
        /// <summary>
        /// A tolerance for floating point comparisons.
        /// </summary>
        const double tolerance = 1e-13;


        /// <summary>
        /// Different densities to test with.
        /// </summary>
        static class Density
        {
            public const double Iron = 7870d;
            public const double Aluminium = 2710d;
        }

        #region Test data for flat discs
        
        /*
          This test data is used to build flywheels with different segments, with differing densities.
        */


        /// <summary>
        /// Volume of disc, 1m radius, 1mm thick.
        /// </summary>
        const double Volume_1m_Disk = Math.PI * 0.001;

        /// <summary>
        /// Volume of ring, 1m outer radius, 0.9m inner radius, 1mm thick.
        /// </summary>
        const double Volume_1000mm_100mm_Ring = Volume_1m_Disk - Volume_900mm_400mm_Ring - Volume_500mm_500mm_Disk;

        /// <summary>
        /// Volume of ring, 0.9m outer radius, 0.5m inner radius, 1mm thick.
        /// </summary>
        const double Volume_900mm_400mm_Ring = Math.PI * (0.9 * 0.9) * 0.001 - Volume_500mm_500mm_Disk;

        /// <summary>
        /// Volume of disc, 0.5m radius, 1mm thick
        /// </summary>
        const double Volume_500mm_500mm_Disk = Math.PI * (0.5 * 0.5) * 0.001;
        #endregion

        #region Test data for sloped segments

        /*
           Volume of conic frustum: V = (1/3) * π * h * (r1^2 + r2^2 + (r1 * r2)) 

            These values are used to build expected volumes for test flywheels with sloping segments.   
        
            Although the thicknesses being used are 0 to 1mm, the calculations are using 0.5mm then multiplying by 2. This is to show that 
            the calculations are done for the volume above the plane of rotation - the specified thickness of T a FlywheelSegment means 0.5T 
            above and below the plane of rotation.
         */

        /// <summary>
        /// Volumes of cone 1mm thick at center i.e. 2 cones of 0.5mm height flat sides together <|>
        /// </summary>
        const double Volume_1m_Cones = 2 * Math.PI * (0.0005 / 3);

        /// <summary>
        /// Volume of a conic frustum ring with thickness 0mm at 1m radius to 1mm thick at 0.5m radius then hollow to the origin. <| | |>
        /// </summary>
        const double Volume_ConicFrustums_Outer = 
            2 * Math.PI / 3 * 0.0005 * (1 * 1 + 0.5 * 0.5 + 1 * 0.5) // Conic frustum: Outer radius 1m thickness 0m to radius 0.5m thickness 0.002m.
            - 2 * Math.PI * (0.5 * 0.5) * 0.0005; // Disc: Radius 0.5m thickness 0.001m

        /// <summary>
        /// Volume of a conic frustum ring with thickness 1mm at 0.5m radius to thickness 0mm at 0m radius. |>|<|
        /// </summary>
        const double Volume_ConicFrustums_Inner = 
           2d * Math.PI * 0.0005 * (0.5 * 0.5) // Disc: 0.5m radius height 0.001m
            - 2d / 3 * Math.PI * 0.0005 * (0.5 * 0.5 + 0 * 0 + 0 * 0.5); // Conic frustum: outer radius:0.5m inner radius:0m Height:0.002m down to 0m     


        /// <summary>
        /// Volume of a conic frustum ring with thickness 1mm at 1m radius to thickness 0mm at 0.5m radius then hollow to the origin. |> | <|
        /// </summary>
        const double Volume_ConicFrustums_Outer2 = // Outer part:     > | <
            2 * Math.PI * (1 * 1) * 0.0005 // Disc: Radius 0.5m thickness 0.001m   
            - 2 * Math.PI / 3 * 0.0005 * (1 * 1 + 0.5 * 0.5 + 1 * 0.5); // Conic frustum: Outer radius 1m thickness 0m to radius 0.5m thickness 0.002m.

        #endregion

        /// <summary>
        /// Test the function used to calculate the volume of sloped segments of the flywheel.
        /// These 
        /// </summary>
        /// <param name="innerRadius"></param>
        /// <param name="outerRadius"></param>
        /// <param name="innerThickness"></param>
        /// <param name="outerThickness"></param>
        /// <param name="expected"></param>
        [Test(Description = "Tests the function used to calculate the volume of sloped segments of the flywheel.")]
        [TestCase(0,1,0.001,0.001, Volume_1m_Disk, Description ="Basic flat disc")]   // Flat disc: ==|==
        [TestCase(0, 1, 0.0005, 0, 0.5*Volume_1m_Cones, Description = "Basic cone" )] // Cone:    /|\
        [TestCase(0.5, 1, 0.0005, 0, 0.5* Volume_ConicFrustums_Outer, Description = "Conic frustum ring")] // Conic frustum ring sloping up from outer 1m to inner 0.5m:   /|  |  |\ 
        [TestCase(0, 0.5, 0, 0.0005, 0.5*Volume_ConicFrustums_Inner, Description = "Inverted conic frustum ring with center at 0")] // Conic frustum ring sloping down from outer 1m to inner 0m:   |\|/|
        [TestCase(0.5, 1, 0, 0.0005, 0.5 * Volume_ConicFrustums_Outer2, Description = "Inverted conic frustum ring with non-zero center")] // Conic frustum ring sloping down from outer 1m to inner 0.5m:   |\_|_/|
        public void TestVolumeOfConicFrustumRing(double innerRadius, double outerRadius, double innerThickness, double outerThickness, double expected)
        {
            double actual = FlywheelSection.VolumeOfConicFrustumRing(innerRadius, outerRadius, innerThickness, outerThickness);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase(new int[] { 1000 }, new int[] { 0, 1 }, new double[] { Density.Iron }, Volume_1m_Cones * Density.Iron, Description = "<|>")]
        [TestCase(new int[] { 500, 500 }, new int[] { 0, 1,0, 0 }, new double[] { Density.Iron, Density.Iron }, Volume_ConicFrustums_Outer * Density.Iron, Description = "< | >")]
        [TestCase(new int[] { 500, 500 }, new int[] { 0,1,1,0 }, new double[] { Density.Iron, Density.Aluminium }, Volume_ConicFrustums_Outer * Density.Iron + Volume_ConicFrustums_Inner * Density.Aluminium, Description = "<>|<>")]
        public void TestMass_SlopedRegions(int[] radii, int[] thicknesses, double[] densities, double expectedMass)
        {
            var sections = FlywheelTestUtilities.CreateSlopedSections(radii, thicknesses, densities);

            IFlywheel fw = new SectionedFlywheel(sections);

            foreach (var section in sections)
            {
                System.Console.WriteLine($"{section.Name} | From outer radius: {section.OuterRadius} to inner radius: {section.InnerRadius} | Thickness: {section.OuterThickness} to {section.InnerThickness}");
            }

            Assert.AreEqual(expectedMass, fw.Mass, tolerance);
        }

        [Test]
        [TestCase(new int[] { 1000 }, new int[] { 1 }, new double[] { Density.Iron }, Volume_1m_Disk * Density.Iron)]
        [TestCase(new int[] { 400, 500 }, new int[] { 1, 0 }, new double[] { Density.Iron, 0 }, Volume_900mm_400mm_Ring * Density.Iron)]
        [TestCase(new int[] { 1000 }, new int[] { 1 }, new double[] { Density.Aluminium }, Volume_1m_Disk * Density.Aluminium)]
        [TestCase(new int[] { 100, 400, 500 }, new int[] { 1, 1, 1 }, new double[] { Density.Iron, Density.Iron, Density.Iron }, Volume_1m_Disk * Density.Iron)]
        [TestCase(new int[] { 100, 400, 500 }, new int[] { 1, 1, 1 }, new double[] { Density.Iron, Density.Aluminium, Density.Iron }, Volume_1000mm_100mm_Ring * Density.Iron + Volume_900mm_400mm_Ring * Density.Aluminium + Volume_500mm_500mm_Disk * Density.Iron)]
        [TestCase(new int[] { 100, 400, 500 }, new int[] { 1, 1, 0 }, new double[] { Density.Iron, Density.Iron, Density.Iron }, (Volume_1000mm_100mm_Ring + Volume_900mm_400mm_Ring) * Density.Iron)]
        [TestCase(new int[] { 100, 400, 500 }, new int[] { 1, 1, 0 }, new double[] { Density.Aluminium, Density.Iron, Density.Aluminium }, Volume_1000mm_100mm_Ring * Density.Aluminium + Volume_900mm_400mm_Ring * Density.Iron)]

        public void TestMass_FlatRegions(int[] radii, int[] thicknesses, double[] densities, double expectedMass)
        {
            var sections = FlywheelTestUtilities.CreateBlockSections(radii, thicknesses, densities);

            IFlywheel fw = new SectionedFlywheel(sections);

            Assert.AreEqual(expectedMass, fw.Mass, tolerance);
        }

        [Test]
        [TestCase(new int[] { 1000 }, new int[] { 1 }, 0.0015707963267948967, TestName = "Moment of Inertia: Solid Disk - 1 section")]
        [TestCase(new int[] { 100, 400, 500 }, new int[] { 1, 1, 1 }, 0.0015707963267948967, TestName = "Moment of Inertia: Solid Disk - 3 sections")]
        [TestCase(new int[] { 100, 400, 500 }, new int[] { 1, 1, 0 }, 0.0014726215563702157, TestName = "Moment of Inertia: Hollow Disk - 3 sections")]
        public void TestMomentOfInertia_MultipleSectionsSingleDensity(int[] radii, int[] thicknesses, double expectedI)
        {
            var sections = FlywheelTestUtilities.CreateBlockSections(radii, thicknesses);

            IFlywheel fw = new SectionedFlywheel(sections);

            Assert.AreEqual(sections.Max(s => s.OuterRadius), fw.Radius, tolerance);
            Assert.AreEqual(expectedI, fw.MomentOfInertia, tolerance);
        }
    }
}
