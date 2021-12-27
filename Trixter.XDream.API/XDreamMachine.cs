using System;

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
        /// Meter that determines the crank speed and direction from incoming state data.
        /// </summary>
        ICrankMeter CrankMeter { get; }


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