using System;

namespace Trixter.XDream.API
{
    [Flags]
    public enum XDreamControllerButtons
    {
        None = 0,
        LeftArrow = 4096,
        RightArrow = 16384,
        UpArrow = 256,
        DownArrow = 1024,

        Blue = 8192,
        Red = 512,
        Green = 2048,
        
        Seated = 8,

        FrontGearUp = 32768,
        FrontGearDown = 128,

        BackGearUp = 32,
        BackGearDown = 64

    }

}
