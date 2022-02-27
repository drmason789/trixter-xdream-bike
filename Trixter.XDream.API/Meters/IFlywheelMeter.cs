using System;

namespace Trixter.XDream.API.Meters
{
    public interface IFlywheelMeter
    {

        /// <summary>
        /// The raw flywheel revolution time from the last data sample in centiseconds.
        /// </summary>
        int RawValue { get; }


        /// <summary>
        /// The calculated revolutions per minute.
        /// </summary>
        int RPM { get; }

        /// <summary>
        /// Angular velocity in radians per second.
        /// </summary>
        double AngularVelocity { get; }

        void AddData(DateTimeOffset timestamp, int rawValue);

        void AddData(XDreamState state);


    }

}

