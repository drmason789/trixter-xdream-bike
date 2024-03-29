﻿using System;

namespace Trixter.XDream.API
{

    /// <summary>
    /// Writeable implementation of <see cref="XDreamState"/> to build valid read-only <see cref="XDreamState"/> objects.
    /// </summary>
    public class XDreamStateBuilder : XDreamState
    {
        private int crank = 0;
        private int crankPosition = CrankPositions.MinCrankPosition;
        private int flywheel = Constants.MaxFlywheelReading;
        private int heartRate = 0;
        private int leftBrake = Constants.MaxBrake;
        private int rightBrake = Constants.MaxBrake;
        private int steering = Constants.MidSteering;
        private DateTimeOffset timeStamp;
        
        private bool HasButton(XDreamControllerButtons which) => (this.Buttons & which) == which;
        private void SetButton(XDreamControllerButtons which, bool value)
        {
            if (value)
                this.Buttons |= which;
            else
                this.Buttons &= ~which;
        }

        private static void AssertRange(int value, int min, int max)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(nameof(value));
        }

        public bool FrontGearUp
        {
            get => this.HasButton(XDreamControllerButtons.FrontGearUp);
            set => this.SetButton(XDreamControllerButtons.FrontGearUp, value);
        }
        public bool FrontGearDown
        {
            get => this.HasButton(XDreamControllerButtons.FrontGearDown);
            set => this.SetButton(XDreamControllerButtons.FrontGearDown, value);
        }
        public bool BackGearUp
        {
            get => this.HasButton(XDreamControllerButtons.BackGearUp);
            set => this.SetButton(XDreamControllerButtons.BackGearUp, value);
        }
        public bool BackGearDown
        {
            get => this.HasButton(XDreamControllerButtons.BackGearDown);
            set => this.SetButton(XDreamControllerButtons.BackGearDown, value);
        }
        public bool Seated
        {
            get => this.HasButton(XDreamControllerButtons.Seated);
            set => this.SetButton(XDreamControllerButtons.Seated, value);
        }
        public bool UpArrow
        {
            get => this.HasButton(XDreamControllerButtons.UpArrow);
            set => this.SetButton(XDreamControllerButtons.UpArrow, value);
        }
        public bool DownArrow
        {
            get => this.HasButton(XDreamControllerButtons.DownArrow);
            set => this.SetButton(XDreamControllerButtons.DownArrow, value);
        }
        public bool LeftArrow
        {
            get => this.HasButton(XDreamControllerButtons.LeftArrow);
            set => this.SetButton(XDreamControllerButtons.LeftArrow, value);
        }
        public bool RightArrow
        {
            get => this.HasButton(XDreamControllerButtons.RightArrow);
            set => this.SetButton(XDreamControllerButtons.RightArrow, value);
        }
        public bool Red
        {
            get => this.HasButton(XDreamControllerButtons.Red);
            set => this.SetButton(XDreamControllerButtons.Red, value);
        }
        public bool Green
        {
            get => this.HasButton(XDreamControllerButtons.Green);
            set => this.SetButton(XDreamControllerButtons.Green, value);
        }
        public bool Blue
        {
            get => this.HasButton(XDreamControllerButtons.Blue);
            set => this.SetButton(XDreamControllerButtons.Blue, value);
        }

        public XDreamControllerButtons Buttons { get; set; }

        public int Crank
        {
            get => crank;
            set
            {
                if (!CrankPositions.IsValidCrankTimeReading(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                crank = value;
            }
        }

        public int CrankPosition
        {
            get => crankPosition;
            set
            {
                if (!CrankPositions.IsValidCrankPosition(value))
                    throw new ArgumentOutOfRangeException(nameof(value));
                crankPosition = value;
            }
        }

        public int Flywheel
        {
            get => flywheel;
            set
            {
                AssertRange(value, Constants.MinFlywheelReading, Constants.MaxFlywheelReading);
                this.flywheel = value;
            }
        }
        public int HeartRate
        {
            get => heartRate;
            set
            {
                AssertRange(value, Constants.MinHeartRate, Constants.MaxHeartRate);
                this.heartRate = value;
            }
        }

        public int LeftBrake
        {
            get => leftBrake; 
            set
            {
                AssertRange(value, Constants.MinBrake, Constants.MaxBrake);
                this.leftBrake = value;
            }
        }

        public int RightBrake
        { 
            get => rightBrake;
            set
            { 
                AssertRange(value, Constants.MinBrake, Constants.MaxBrake);
                this.rightBrake = value;
            }
        }

        public int Steering
        {
            get => steering;
            set
            {
                AssertRange(value, Constants.MinSteering, Constants.MaxSteering);
                this.steering = value;
            }
        }

        public DateTimeOffset TimeStamp { get => timeStamp; set { this.timeStamp = value; } }

        public XDreamState ToReadOnly() => new XDreamStateObject(this);

    }
}