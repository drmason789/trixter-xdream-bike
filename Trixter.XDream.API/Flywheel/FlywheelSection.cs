using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Flywheel
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class FlywheelSection
    {
        public const double DefaultDensity = 1;

        private readonly double? slope;
        
        private int? innerRadius;
        private string debuggerDisplay = null;
           

        /// <summary>
        /// Volume of a conic frustum ring with the specified parameters, in cubic meters.
        /// </summary>
        /// <param name="innerRadius">Inner radius in meters.</param>
        /// <param name="outerRadius">Outer radius in meters.</param>
        /// <param name="innerThickness">Inner thickness in meters.</param>
        /// <param name="outerThickness">Outer thickness in meters.</param>
        /// <returns></returns>
        static internal double VolumeOfConicFrustumRing(double innerRadius, double outerRadius, double innerThickness, double outerThickness)
        {
            double dh = innerThickness - outerThickness;
            double ir2 = innerRadius * innerRadius, or2 = outerRadius * outerRadius;
            double vf = Math.PI / 3 * (ir2 + or2 + innerRadius * outerRadius) * Math.Abs(dh);
            double result = 0;

            if (dh>0)
            {
                // frustum - inner disc     
                double vd = Math.PI * ir2 * innerThickness;

                result = vf - vd;
            }
            else
            {
                // outer disc - frustum
                double vd = Math.PI * or2 * outerThickness;

                result = vd - vf;
            }

            return result;
        }

        private string DebuggerDisplay
        { 
            get
            {
                if (this.debuggerDisplay == null)
                    this.debuggerDisplay = $"{InnerRadius:D3}mm-{OuterRadius:D3}mm : {InnerThickness:D2}mm-{OuterThickness:D2}mm Mass:{CalculateMass()}kg";
                return this.debuggerDisplay;
            }
        }

        /// <summary>
        /// The name of the section.
        /// </summary>
        public string Name { get; }

        public bool HasMass => (this.InnerThickness > 0 || this.OuterThickness > 0) && this.Density > 0d;

        public int DeltaRadius { get; }

        /// <summary>
        /// Inner thickness in millimeters.
        /// </summary>
        public int InnerThickness { get; }

        /// <summary>
        /// Outer thickness in millimeters.
        /// </summary>
        public int OuterThickness { get; }


        public int OuterRadius { get; private set;  }

        private void AssertInnerRadius()
        {
            if (innerRadius == null)
                throw new InvalidOperationException(nameof(this.InnerRadius) + " is not set.");
        }

        public int InnerRadius 
        {
            get 
            {
                this.AssertInnerRadius();

                return this.innerRadius.Value;
            }
            set
            {
                if (this.innerRadius != value)
                {
                    this.debuggerDisplay = null;
                    this.innerRadius = value;
                    this.OuterRadius = this.innerRadius.Value + this.DeltaRadius;
                }
            }
        }

        /// <summary>
        /// Density in kg/m^3.
        /// </summary>
        public double Density { get; }

        public FlywheelSection(string name, int deltaR, int innerThickness, double density=DefaultDensity)
            : this(name, deltaR, innerThickness, innerThickness, density) { }

        public FlywheelSection(string name, int deltaR,  int innerThickness, int outerThickness, double density=DefaultDensity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{this.GetType().Name} must have a name to distinguish it from others.");
            if (deltaR<0)
                throw new ArgumentOutOfRangeException(nameof(deltaR));
            if (innerThickness < 0)
                throw new ArgumentOutOfRangeException(nameof(innerThickness));
            if (outerThickness < 0)
                throw new ArgumentOutOfRangeException(nameof(outerThickness));
            if (density < 0)
                throw new ArgumentOutOfRangeException(nameof(density));

            this.Name = name;
            this.DeltaRadius = deltaR;
            this.InnerThickness = innerThickness;
            this.OuterThickness = outerThickness;

            this.Density = density;

            if (innerThickness != outerThickness)
                this.slope = (double)(outerThickness - innerThickness) / deltaR;
            else 
                this.slope = null;           
        }

        /// <summary>
        /// Get the thickness in millimeters at the specified radius (in millimeters).
        /// </summary>
        /// <param name="radius">Radius in millimeters.</param>
        /// <returns></returns>
        protected double GetThickness(int radius)
        {
            this.AssertInnerRadius();

            if (radius < this.InnerRadius) return 0;
            if (radius > this.OuterRadius) return 0;

            if (!this.slope.HasValue)
                return this.InnerThickness;

            if (radius == this.OuterRadius) return this.OuterThickness;
            if (radius == this.InnerRadius) return this.InnerThickness;
                      
            int r = radius - this.InnerRadius;
            return slope.Value * r + this.InnerThickness;
        }

        public double CalculateMass() 
            => this.Density * this.CalculateVolume();

        public double CalculateMass(int innerRadius, int outerRadius)
            => this.Density * this.CalculateVolume(innerRadius, outerRadius);

        public double CalculateVolume() 
            => this.CalculateVolume(this.InnerRadius, this.OuterRadius);

        /// <summary>
        /// Calculates the volume in m^3.
        /// </summary>
        /// <param name="innerRadius">Inner radius in mm.</param>
        /// <param name="outerRadius">Outer radius in mm.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public double CalculateVolume(int innerRadius, int outerRadius)
        {
            this.AssertInnerRadius();

            if (outerRadius == innerRadius)
                return 0;
            if (outerRadius < innerRadius)
                throw new ArgumentException("Arguments out of order.");

            double ir = 0.001*Math.Max(this.InnerRadius, innerRadius);
            double or = 0.001*Math.Min(this.OuterRadius, outerRadius);
            double it = 0.001 * this.InnerThickness;

            double result;

            if (this.slope == null)
            {
                double ir2 = ir * ir, or2 = or * or;
                result = Math.PI * (or2 - ir2) * it;
            }
            else
            {
                // This segment is sloped - it's a pair of conic frustum rings on wither side of the plane of rotation
                //        __  __
                //       / |  | \       or         |\    /|
                //      |  |  |  |                 | |  | | ----------- plane of rotation  
                //       \_|  |_/                  |/    \|
                //
                // Calculate the volume of one half of the segment then multiply by 2
                double ot = 0.0005 * this.OuterThickness;
                double vh = VolumeOfConicFrustumRing(ir, or, 0.5 * it, ot);
                result = 2*vh;
            }

            return result;
        }

        private double CalculateMomentOfInertia(int innerRadius, int outerRadius)
        {
            double mass = CalculateMass(innerRadius, outerRadius);
            double ir = 0.001 * innerRadius, or = 0.001 * outerRadius;
            double result = mass * 0.5 * (or * or + ir * ir);
            return result;
        }

        /// <summary>
        /// Calculates the moment of inertia of the segment.
        /// </summary>
        /// <param name="delta">Slice width for non-flat segments.</param>
        /// <returns></returns>
        public double CalculateMomentOfInertia(int delta)
        {
            this.AssertInnerRadius();

            double result = 0;

            if (this.slope == 0)
            {
                result = CalculateMomentOfInertia(this.InnerRadius, this.OuterRadius);
            }
            else
            {
                for (int r0 = this.InnerRadius; r0 < this.OuterRadius; r0 += delta)
                {
                    int r1 = Math.Min(this.OuterRadius, r0 + delta);

                    result += CalculateMomentOfInertia(r0, r1);
                }
            }

            return result;
        }
    }

}
