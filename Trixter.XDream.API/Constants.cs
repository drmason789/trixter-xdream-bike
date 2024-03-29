﻿using System;

namespace Trixter.XDream.API
{
    public static class Constants
    {
        public const int MaxHeartRate = 255;
        public const int MinHeartRate = 0; // no reading


        public const int MaxFlywheelReading = 65535; // 65534 is no movement
        public const int MinFlywheelReading = 0; // Warp 10 on the TNG scale.

        public const int MaxBrake = 250; // full off
        public const int MinBrake = 135; // full on

        public const int MaxSteering = 255; // right
        public const int MidSteering = (MaxSteering+MinSteering)>>1;
        public const int MinSteering = 0; // left


        public const int MillisecondsPerSecond = 1000;
        public const int MillisecondsPerMinute = SecondsPerMinute * MillisecondsPerSecond;
        public const int SecondsPerMinute = 60;

        public const double RpmToRadiansPerSecond = Math.PI * 2 / Constants.SecondsPerMinute;
        public const double RadiansPerSecondToRpm = 1.0d / RpmToRadiansPerSecond;
        public const double RadiansToRevolutions = 0.5 / Math.PI;

        public const string StateTimestampError = "Timestamp is prior to the previous.";
    }

}
