﻿using System;
using System.Diagnostics;
using System.Linq;

namespace Trixter.XDream.API
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal class XDreamMessage : XDreamState    
    {
        /* Packet content
         *                            6A 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
         * (00) Header ---------------+  |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
         * (01) Steering ----------------+  |  |  |  |  |  |  |  |  |  |  |  |  |  |
         * (02) Unknown --------------------+  |  |  |  |  |  |  |  |  |  |  |  |  |
         * (03) Crank position ----------------+  |  |  |  |  |  |  |  |  |  |  |  |
         * (04) Right brake ----------------------+  |  |  |  |  |  |  |  |  |  |  |
         * (05) Left brake --------------------------+  |  |  |  |  |  |  |  |  |  |
         * (06) Unknown --------------------------------+  |  |  |  |  |  |  |  |  |
         * (07) Unknown -----------------------------------+  |  |  |  |  |  |  |  |
         * (08) Button flags ---------------------------------+  |  |  |  |  |  |  |
         * (09) Button flags ------------------------------------+  |  |  |  |  |  |
         * (0A) Crank revolution time (high byte) ------------------+  |  |  |  |  |
         * (0B) Crank revolution time (low byte) ----------------------+  |  |  |  |
         * (0C) Flywheel Revolution Time (high byte) ---------------------+  |  |  |
         * (0D) Flywheel Revolution Time (low byte) -------------------------+  |  |
         * (0E) Heart rate (BPM) -----------------------------------------------+  |
         * (0F) Unknown -----------------------------------------------------------+
         */

        internal static readonly Func<int, int> flywheelRawToRpm = x => x <= 0 ? int.MaxValue : (x >= 65534 ? 0 : (int)(1<<19) / x );
        

        internal const int MessageSize = 32;
        internal const string MessageHeader = "6a";
        public const int Error = -1;

        private const int packetLength = 16;

        internal byte[] rawInput;

        private string DebuggerDisplay => $"{TimeStamp:mm:ss.fff} : {Buttons}";

        /// <summary>
        /// Raw data from device.
        /// </summary>
        public byte[] RawInput => this.rawInput.ToArray(); // make a copy to avoid editing

        public DateTimeOffset TimeStamp { get; }

        public XDreamControllerButtons Buttons { get; }


        public XDreamMessage(byte[] rawInput, DateTimeOffset? timeStamp = null)
        {
            if (rawInput == null)
                throw new ArgumentNullException(nameof(rawInput));

            if (rawInput.Length != packetLength)
                throw new ArgumentException(nameof(rawInput));

            if (rawInput[0] != 0x6a)
                throw new ArgumentException("Invalid header.", nameof(rawInput));

            this.rawInput = rawInput;
            this.TimeStamp = timeStamp ?? DateTimeOffset.Now;
            this.Buttons = (XDreamControllerButtons)(65535 - (256 * this.rawInput[8] + this.rawInput[9]));
        }

        public int Steering => (int)this.rawInput[1];
        public int LeftBrake => (int)this.rawInput[5];
        public int RightBrake => (int)this.rawInput[4];


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


        /// <summary>
        /// Crank speed measurement. 
        /// </summary>
        public int Crank => 256 * this.rawInput[10] + this.rawInput[11];

        /// <summary>
        /// The crank position, 1..60.
        /// </summary>
        public int CrankPosition => (int)this.rawInput[3];

        /// <summary>
        /// Flywheel speed measurement.
        /// </summary>
        public int Flywheel => this.rawInput[12] * 256 + this.rawInput[13];


        /// <summary>
        /// The calculated RPM of the flywheel.
        /// </summary>
        public int FlywheelRPM => flywheelRawToRpm(this.Flywheel);

        public int HeartRate => (int)this.rawInput[14];

        #region Unknown values
        public int Other2 => (int)this.rawInput[2];
        public int Other6 => (int)this.rawInput[6];
        public int Other7 => (int)this.rawInput[7];

        /// <summary>
        /// Unknown from last byte, seems to change with most inputs.
        /// Perhaps a change type indicator?
        /// </summary>
        public int Other15 => (int)this.rawInput[15];
        #endregion

    }

    
}
