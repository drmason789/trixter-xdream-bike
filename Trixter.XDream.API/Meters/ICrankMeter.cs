using System;
using System.Diagnostics;

namespace Trixter.XDream.API.Meters
{
    public interface ICrankMeter
    {
        /// <summary>
        /// Indicates if the object is ready to provide cadence data.
        /// </summary>
        bool HasData { get; }

        /// <summary>
        /// Reset the object.
        /// </summary>
        void Reset();


        /// <summary>
        /// The direction of crank motion.
        /// </summary>
        CrankDirection Direction { get; }


        /// <summary>
        /// Angular velocity in radians per second.
        /// </summary>
        double AngularVelocity { get; }

        /// <summary>
        /// The calculated revolutions per minute.
        /// </summary>
        int RPM { get; }

        /// <summary>
        /// The crank position in the last data sample.
        /// </summary>
        int CrankPosition { get; }


        /// <summary>
        /// The raw crank revolution time from the last data sample. Unknown units.
        /// </summary>
        int RawValue { get; }

        /// <summary>
        /// The maximum number of milliseconds between messages for them to be considered sequential.
        /// </summary>
        int MaximumMessageInterval { get; }

        /// <summary>
        /// Add the crank position and uninterpreted revolution time data.
        /// </summary>
        /// <param name="timestamp">The timestamp for the sample. Should be later than the previous.</param>
        /// <param name="crankPosition"></param>
        /// <param name="rawData"></param>
        void AddData(DateTimeOffset timestamp, int crankPosition, int rawData);

        /// <summary>
        /// Add data from an <see cref="XDreamState"/> object.
        /// </summary>
        /// <param name="state"></param>
        void AddData(XDreamState state);
        
    }

}
