using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class CrankMeterTests
    {
        
        [Test(Description ="Test that if a timestamp later than one that has already been received is passed, an ArgumentException is thrown.")]
        [TestCase(typeof(PositionalCrankMeter))]
        [TestCase(typeof(MappedCrankMeter))]
        [TestCase(typeof(HybridCrankMeter))]

        public void TestForReversingTimestamp(Type statisticsType)
        {
            ICrankMeter cs = (ICrankMeter)statisticsType.GetConstructor(Array.Empty<Type>()).Invoke(null);
            DateTimeOffset t0 = DateTimeOffset.UtcNow;

            cs.AddData(t0, 1, 0);
            Assert.Throws<ArgumentException>(() => cs.AddData(t0.AddMilliseconds(-1), 2, CrankPositions.MinCrankTimeReading));

        }


        /// <summary>
        /// Generate an array of cadence data.
        /// </summary>
        /// <param name="rpm">The speed in revolutions per minute. Use a negative value for backward cadence.</param>
        /// <param name="sampleIntervalMilliseconds"></param>
        /// <param name="lengthMilliseconds"></param>
        /// <param name="startTimestamp"></param>
        /// <param name="rpmToRaw">Functor to calculate the raw crank reading from the RPM.</param>
        /// <param name="flywheelReading">Functor to provide a flywheel reading at a specified number of milliseconds since the start time.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static XDreamState [] GenerateCadenceData(int rpm, int sampleIntervalMilliseconds, int lengthMilliseconds, DateTimeOffset startTimestamp,
            Func<int,int> rpmToRaw, Func<int, int> flywheelReading)
        {
            if(sampleIntervalMilliseconds < 1)
                throw new ArgumentOutOfRangeException(nameof(sampleIntervalMilliseconds));
            if (lengthMilliseconds < sampleIntervalMilliseconds)
                throw new ArgumentException(nameof(sampleIntervalMilliseconds));
            if (rpmToRaw == null)
                throw new ArgumentNullException(nameof(rpmToRaw));
            if (flywheelReading == null)
                throw new ArgumentNullException(nameof(flywheelReading));

            double dt= sampleIntervalMilliseconds;  
            double dp_dt = 0.01 * rpm;
            double t = 0, p = CrankPositions.MinCrankPosition;

            XDreamStateBuilder builder = new XDreamStateBuilder
            {
                Crank = rpm > 0 ? Math.Min(65535, Math.Max(0, rpmToRaw(rpm))) : 0,
                CrankPosition = CrankPositions.MinCrankPosition
            };

            List<XDreamState> result = new List<XDreamState>();

            while(t<lengthMilliseconds)
            {
                if ((int)p != builder.CrankPosition)
                    builder.CrankPosition = CrankPositions.Add(builder.CrankPosition, (int)p - builder.CrankPosition);
                builder.Flywheel = flywheelReading((int)t);
                builder.TimeStamp = startTimestamp.AddMilliseconds(t);
            
                result.Add(builder.ToReadOnly());

                t += dt;
                p += dp_dt;
            }

            return result.ToArray();

        }
    }
}
