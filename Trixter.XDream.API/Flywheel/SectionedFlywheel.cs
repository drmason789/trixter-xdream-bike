using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API.Flywheel
{

    /// <summary>
    /// An implementation of <see cref="IFlywheel"/> that is defined using a set of <see cref="FlywheelSection"/> objects defining the thickness
    /// and density of the specified section. 
    /// </summary>
    public class SectionedFlywheel : IFlywheel
    {
        private FlywheelSection[] sections;
        private FlywheelSection[] sectionsWithMass;
        private double? densityAdjustment;

        public int Radius { get; }
        public double Mass { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sectionsOuterToInner">Sections from outer (maximum radius) to inner (minimum radius).
        /// Last section will have <see cref="FlywheelSection.InnerRadius"/> set to 0.</param>
        /// <param name="mass">Optional mass of the flywheel. If the calculated mass of the flywheel does not match this, 
        /// an adjustment will be calculated.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public SectionedFlywheel(IEnumerable<FlywheelSection> sectionsOuterToInner, double? mass=null)
        {
            if(sectionsOuterToInner == null)
                throw new ArgumentNullException(nameof(sectionsOuterToInner));

            this.sections = sectionsOuterToInner.ToArray();
            HashSet<String> usedNames = new HashSet<string>();

            List<String> errors = new List<string>();

            for(int i=0; i<this.sections.Length; i++)
            {
                if (!usedNames.Add(this.sections[i].Name))
                    errors.Add($"Section {i}:{this.sections[i].Name} : Name not unique.");
            }

            if (errors.Count > 0)
                throw new ArgumentException(String.Join(Environment.NewLine, errors), nameof(sections));

            this.sections[sections.Length - 1].InnerRadius = 0;
            for (int i = sections.Length - 2; i >= 0; i--)
                sections[i].InnerRadius = sections[i + 1].OuterRadius;
            this.sectionsWithMass = sections.Where(s => s.HasMass).ToArray();

            double calculatedMass  = this.sectionsWithMass.Sum(s => s.CalculateMass());

            if (mass.HasValue && mass.Value!= calculatedMass)
            {
                this.densityAdjustment = mass.Value / calculatedMass;
                calculatedMass = mass.Value;
            }

            this.Radius = this.sectionsWithMass.Max(s => s.OuterRadius);
            this.Mass = calculatedMass;
        }
   
    }

}
