using System;
using System.Collections.Generic;
using System.Text;

namespace Trixter.XDream.API.Generators
{
    
    public interface ICadenceProvider
    {
        /// <summary>
        /// Event called when crank position changes.
        /// </summary>
        event CrankPositionChangedDelegate<ICadenceProvider> CrankPositionChanged;

        /// <summary>
        /// The current crank position. Setting the crank position resets internal trip data.
        /// </summary>
        int CrankPosition { get; set; }

        /// <summary>
        /// The required revolutions per minute. 
        /// </summary>
        int RPM { get; set; }

        /// <summary>
        /// The number of milliseconds per position at the current <see cref="RPM"/>.
        /// </summary>
        double MillisecondsPerPosition { get; }

        /// <summary>
        /// Update the crank position using the RPM, the specified timestamp, and the time since the previous call to this function.
        /// </summary>
        /// <param name="timestamp"></param>
        void Update(DateTimeOffset timestamp);

    }
}
