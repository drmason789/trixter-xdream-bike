using System;

namespace Trixter.XDream.API.Flywheel
{

    /// <summary>
    /// Implementation of <see cref="IFlywheel"/> using measurements from an X-Dream V1 bike.
    /// </summary>
    public class XDreamFlywheel : SectionedFlywheel
    {
        /*
             X-Dream Flywheel Cross Section 

              
                                                              i 
                                                             +-+
                                                         f gh| | j
               b                                           +-+ | k  l
             +---+                                    e   /    +--+   +
             |   | c                  d                  /        |   |
           a |   +--------------------------------------+         |   |
             |                                         m          |   |
             |   +--------------------------------------+         |   |
            
                                      n  
             |<----------------------------------------------------->|

            a) rim is 30mm thick
            b) rim radial thickness is 15mm
            c) difference between rim thickness and body thickess (l) is 10mm
            d) main body radius = 170mm
            e) height of axle mound = ~28mm
            f) radius of sloped section estimated 8mm
            g) rim of axle mound = 4mm
            h) height of bearing mount above axle mound = 8mm
            i) rim of bearing mount = 3mm
            j) depth of bearing mount = 24mm (estimated from memory of putting 2 12mm thick bearings in
            k) inner ridge of bearing mount = 3mm (estimated from vague memory of shape)
            l) radius of axle cavity calculated as n - k-i-g-f-d-b = 17mm
            m) body thickness = rim thickness = a-2*c = 14mm
            n) total length, measured approximately, = 220mm

            This values are not as accurate as they could be if I remove the flywheel and measure.
            k+l should be 13, which is the radius of the bearing that fits in that section.
            */

        internal const int XDreamFlywheelExpectedMassKilograms = 15;
        internal const int XDreamFlywheelRadiusMillimeters = 220;
        internal const double Density = 7870; // density of iron, which I presume the material to be

        private static readonly FlywheelSection [] XDreamFlyWheelSections =
            new FlywheelSection[] {
            new FlywheelSection("Outer Rim", 15, 30, 30, Density),
            new FlywheelSection("Body", 170,  10, 10,Density),
            new FlywheelSection("Axle Mound Sloped Section", 8, 66, 10,Density),
            new FlywheelSection("Axle Mound Inner Rim", 4, 66,Density),
            new FlywheelSection("Bearing Mount Protrusion", 3,  82,Density),
            new FlywheelSection("Bearing Mount Internal Ridge", 3,  50,Density),
            new FlywheelSection("Axle Cavity", 17, 0,Density)
            };

        /// <summary>
        /// Create an XDreamFlywheel object with a mass from a constant resulting from a physcial measurement rather than 
        /// calculated from the configured density and volume of the segments.
        /// </summary>
        /// <returns></returns>
        public static XDreamFlywheel CreateDefault() => new XDreamFlywheel(XDreamFlywheelExpectedMassKilograms);

        public XDreamFlywheel(double? mass) : base(XDreamFlyWheelSections, mass)
        {
            if (this.Radius != XDreamFlywheelRadiusMillimeters)
                throw new Exception("Flywheel sections do not yield expected total radius.");
        }
               
    }

}
