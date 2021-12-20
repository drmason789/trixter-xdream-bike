using System;

namespace Trixter.XDream.API
{
    [Flags]
    public enum XDreamStateChanges
    {
        None = 0,

        Blue = 1,
        Green = 2,
        Red = 4,

        BackGearDown = 8,
        BackGearUp = 16,
        
        FrontGearDown = 32,
        FrontGearUp = 64,
        LeftArrow = 128,        
        RightArrow = 256,
        UpArrow = 512,
        DownArrow = 1024,
        Seated = 2048,
        
        Buttons = Blue | Green | Red | BackGearDown | BackGearUp |FrontGearDown | FrontGearUp | LeftArrow | RightArrow | UpArrow | DownArrow | Seated,

        Crank = 4096,
        RightBrake = 8192,
        LeftBrake = 16384,
        HeartRate = 32768,
        CrankPosition = 65536,
        Flywheel = 131072,
        Steering = 262144        
    }
}