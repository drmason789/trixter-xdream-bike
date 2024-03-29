﻿using System;
using System.Diagnostics;

namespace Trixter.XDream.API
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class XDreamStateObject : XDreamState
    {
        private string DebuggerDisplay => $"{TimeStamp:mm:ss.fff} : {CrankPosition} {Crank}";

        internal XDreamStateObject(XDreamState toCopy)
        {
            this.Buttons = toCopy.Buttons;
            this.Steering = toCopy.Steering;
            this.Crank = toCopy.Crank;
            this.CrankPosition = toCopy.CrankPosition;
            this.Flywheel = toCopy.Flywheel;
            this.LeftBrake = toCopy.LeftBrake;
            this.RightBrake = toCopy.RightBrake;
            this.HeartRate = toCopy.HeartRate;
            this.TimeStamp = toCopy.TimeStamp;
        }

        public XDreamControllerButtons Buttons { get; private set; }

        public bool FrontGearUp => this.Buttons.HasFlag(XDreamControllerButtons.FrontGearUp);
        public bool FrontGearDown => this.Buttons.HasFlag(XDreamControllerButtons.FrontGearDown);
        public bool BackGearUp => this.Buttons.HasFlag(XDreamControllerButtons.BackGearUp);
        public bool BackGearDown => this.Buttons.HasFlag(XDreamControllerButtons.BackGearDown);
        public bool Seated => this.Buttons.HasFlag(XDreamControllerButtons.Seated);
        public bool UpArrow => this.Buttons.HasFlag(XDreamControllerButtons.UpArrow);
        public bool DownArrow => this.Buttons.HasFlag(XDreamControllerButtons.DownArrow);
        public bool LeftArrow => this.Buttons.HasFlag(XDreamControllerButtons.LeftArrow);
        public bool RightArrow => this.Buttons.HasFlag(XDreamControllerButtons.RightArrow);
        public bool Red => this.Buttons.HasFlag(XDreamControllerButtons.Red);
        public bool Green => this.Buttons.HasFlag(XDreamControllerButtons.Green);
        public bool Blue => this.Buttons.HasFlag(XDreamControllerButtons.Blue);

        public int Crank { get; private set; }
        public int CrankPosition { get; private set; }
        public int Flywheel { get; private set; }
        public int HeartRate { get; private set; }
        public int LeftBrake { get; private set; }
        public int Other15 { get; private set; }
        public int Other2 { get; private set; }
        public int Other6 { get; private set; }
        public int Other7 { get; private set; }
        public int RightBrake { get; private set; } 
        public int Steering { get; private set; }
        public DateTimeOffset TimeStamp { get; private set; }

        
    }
}