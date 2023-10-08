using System;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API
{

#pragma warning disable IDE1006 // Naming Styles
    public interface XDreamMachine : IDisposable
#pragma warning restore IDE1006 // Naming Styles
    {
        event XDreamStateUpdatedDelegate<XDreamMachine> StateUpdated;

        /// <summary>
        /// Source for the <see cref="XDreamState"/> objects that update the <see cref="XDreamMachine"/>'s state.
        /// </summary>
        XDreamClient DataSource { get; }

        /// <summary>
        /// Meter that determines the flywheel speed from incoming state data.
        /// </summary>
        IFlywheelMeter FlywheelMeter { get; }

        /// <summary>
        /// Meter that calculates the power being applied to the flywheel.
        /// </summary>
        IPowerMeter FlywheelPowerMeter { get; }
        
        /// <summary>
        /// Meter that determines the crank speed and direction from incoming state data.
        /// </summary>
        ICrankMeter CrankMeter { get; }

        /// <summary>
        /// Meter that determines the power being applied to the crank.
        /// </summary>
        IPowerMeter PowerMeter { get; }

        /// <summary>
        /// Meter that determines the cumulative revolutions of the crank and flywheel.
        /// </summary>
        ITripMeter TripMeter { get; }

        /// <summary>
        /// The last reported state of the machine.
        /// </summary>
        XDreamState State { get; }


        /// <summary>
        /// Gets and sets the resistance of the machine.
        /// </summary>
        int Resistance { get; set; }
    }
}