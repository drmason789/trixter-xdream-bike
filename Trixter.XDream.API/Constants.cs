namespace Trixter.XDream.API
{
    internal static class Constants
    {
        public const int MaxHeartRate = 300;
        public const int MinHeartRate = 0; // no reading


        public const int MaxFlywheelReading = 65535; // 65534 is no movement
        public const int MinFlywheelReading = 0; // Warp 10 on the TNG scale.

        public const int MaxBrake = 250; // full off
        public const int MinBrake = 135; // full on

        public const int MaxSteering = 255; // right
        public const int MinSteering = 0; // left
    }

}
