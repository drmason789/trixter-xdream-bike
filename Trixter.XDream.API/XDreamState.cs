using System;

namespace Trixter.XDream.API
{
#pragma warning disable IDE1006 // Naming Styles
    public interface XDreamState
#pragma warning restore IDE1006 // Naming Styles
    {
        bool BackGearDown { get; }
        bool BackGearUp { get; }
        bool Blue { get; }
        XDreamControllerButtons Buttons { get; }
        int Crank { get; }
        int CrankPosition { get; }
        bool DownArrow { get; }
        int Flywheel { get; }
        bool FrontGearDown { get; }
        bool FrontGearUp { get; }
        bool Green { get; }
        int HeartRate { get; }
        bool LeftArrow { get; }
        int LeftBrake { get; }        
        bool Red { get; }
        bool RightArrow { get; }
        int RightBrake { get; }
        bool Seated { get; }
        int Steering { get; }
        DateTimeOffset TimeStamp { get; }
        bool UpArrow { get; }

        
    }

}