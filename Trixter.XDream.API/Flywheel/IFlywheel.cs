using System.Text;

namespace Trixter.XDream.API.Flywheel
{
    public interface IFlywheel
    {
        /// <summary>
        /// Radius in millimeters.
        /// </summary>
        int Radius { get; }


        /// <summary>
        /// Mass in kilograms.
        /// </summary>
        double Mass { get; }
    }

}
