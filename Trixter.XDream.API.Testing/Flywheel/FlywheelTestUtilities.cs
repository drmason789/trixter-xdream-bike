using System;
using System.Linq;
using Trixter.XDream.API.Flywheel;

namespace Trixter.XDream.API.Testing.Flywheel
{
    public static class FlywheelTestUtilities
    {
        /// <summary>
        /// Creates an array of <see cref="FlywheelSection"/> objects with a single thickness across each section.
        /// </summary>
        /// <param name="deltaR">An array of radial thicknesses of each segment.</param>
        /// <param name="thicknesses">An array of thicknesses of each section.</param>
        /// <param name="densities"></param>
        /// <returns></returns>
        public static FlywheelSection[] CreateBlockSections(int[] deltaR, int[] thicknesses, double[] densities = null)
        {
            int[,] t2d = new int[thicknesses.Length, 2];

            for (int i = 0; i < thicknesses.Length; i++)
                t2d[i, 0] = t2d[i, 1] = thicknesses[i];

            return CreateSections(deltaR, t2d, densities);
        }

        /// <summary>
        /// Creates an array of <see cref="FlywheelSection"/> objects with sloping or consistent thickness across the segments.
        /// </summary>
        /// <param name="deltaR">An array of radial thicknesses of each segment.</param>
        /// <param name="thicknesses">An array of thicknesses corresponding to the outer and inner radii (in that order) as a list, i.e.
        /// thicknessOuter0, thicknessInner0, thicknessOuter1, thicknessInner1,...
        /// E.g. 1 sloping to 0.5 then sloping back up to 1 is {1,0.5,0.5, 1} 
        /// 1 for section 1 then 0.5 for section 2 is {1,1,0.5,0.5}</param>
        /// <param name="densities">Optional: the density of each section.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static FlywheelSection[] CreateSlopedSections(int[] deltaR, int[] thicknesses, double[] densities = null)
        {
            if (2 * deltaR.Length != thicknesses.Length || (densities != null && densities.Length != deltaR.Length))
                throw new ArgumentException("Twice as many thicknesses than radius deltas is required, and (optionally) the same number of densities as radii.");

            int[,] t2d = new int[deltaR.Length, 2];

            for (int i = 0; i < deltaR.Length; i++)
            {
                t2d[i, 0] = thicknesses[i * 2 + 1];
                t2d[i, 1] = thicknesses[i * 2];
            }

            return CreateSections(deltaR, t2d, densities);
        }

        /// <summary>
        /// Creates an array of <see cref="FlywheelSection"/> objects with sloping or consistent thickness across the segments.
        /// </summary>
        /// <param name="deltaR">An array of radial thicknesses of each segment.</param>
        /// <param name="thicknesses">An array of pairs of thicknesses corresponding to the outer and inner radii (in that order).</param>
        /// <param name="densities">Optional: the density of each segment.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static FlywheelSection[] CreateSections(int[] deltaR, int[,] thicknesses, double[] densities = null)
        {
            if (deltaR.Length != thicknesses.GetLength(0) || (densities != null && densities.Length != deltaR.Length))
                throw new ArgumentException("The same number of radius deltas, thicknesses and (optionally) densities is required.");

            if (thicknesses.GetLength(1) != 2)
                throw new ArgumentException("2 thicknesses are required for each section.");

            if (deltaR.Length == 0)
                throw new ArgumentException("At least 1 radius delta and thickness is required.");

            var parts = deltaR.Select((r, i) => new { I = i, dR = r, Ti = thicknesses[i, 0], To = thicknesses[i, 1], D = densities?[i] ?? 1d }).ToArray();
            var sections = parts.Select(x => new FlywheelSection($"Section {x.I}", x.dR, x.Ti, x.To, x.D)).ToArray();

            return sections;
        }
    }
}
