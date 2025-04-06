using System;
using System.Collections.Generic;
using Trixter.XDream.API.Filters;


namespace Trixter.XDream.API.Communications
{
    /// <summary>
    /// Implementation of <see cref="XDreamServer"/> that acts as a proxy for a Trixter X-Dream V1 bike over a serial port.
    /// </summary>
    public class XDreamSerialPortServer : XDreamSerialPortBase, XDreamServer
    {
        public const int StateUpdatePulseIntervalMilliseconds = 10;

        /// <summary>
        /// The number of millseconds the requested resistance is sustained.
        /// </summary>
        public const int ResistanceIntervalMilliseconds = 50;

        readonly object resistanceSync = new object();
        int resistanceLevel = 0;
        DateTimeOffset resistanceExpires;
        SampleList resistancePacketSamples = new SampleList();

        private readonly object stateSync = new object();
        private XDreamState state;
        private byte[] stateBytes;

        private readonly DateTimeOffset startTime = DateTimeOffset.UtcNow;
        
        private System.Timers.Timer resistanceTimer;

        public event XDreamResistanceChangedDelegate<XDreamServer> ResistanceChanged;

        private double TimeSinceStart => (DateTimeOffset.UtcNow - this.startTime).TotalMilliseconds;

        public double ResistancePacketsPerSecond 
        { 
            get 
            {
                lock (this.resistancePacketSamples)
                {
                    this.resistancePacketSamples.Trim(this.TimeSinceStart - 1000, null);
                    return this.resistancePacketSamples.Count;
                }
            } 
        }

        public XDreamState State 
        {
            get { lock(this.stateSync) return this.state; }
            set 
            {
                lock (this.stateSync)
                {
                    this.state = value;
                    this.stateBytes = XDreamMessage.GetDataPacketTextBytes(value);
                    this.MessageTimerEnabled = this.state != null;
                }
            } 
        }

        public int Resistance
        {
            get { lock(this.resistanceSync) return this.resistanceLevel; }
            set
            {
                bool changed = false;

                lock (this.resistanceSync)
                {
                    value = Math.Max(0, Math.Min(XDreamSerialData.MaxResistance, value));

                    if (this.resistanceLevel != value)
                    {
                        this.resistanceLevel = value;
                        changed = true;
                    }

                    if (value > 0)
                    {
                        this.resistanceExpires = DateTimeOffset.UtcNow.AddMilliseconds(ResistanceIntervalMilliseconds);
                        this.resistanceTimer.Start();
                    }
                    else
                    {
                        this.resistanceExpires = DateTimeOffset.MaxValue;
                        this.resistanceTimer.Stop();
                    }
                }

                if (changed) this.OnResistanceChanged();
            }
        }

        protected virtual void OnResistanceChanged() => this.ResistanceChanged?.Invoke(this);

        protected override void OnPacketReceived(byte[] packet)
        {
            if(packet?.Length==XDreamSerialData.ResistancePacketLength)
            {
                this.Resistance= packet[1];

                lock(this.resistancePacketSamples)
                {
                    this.resistancePacketSamples.Add(new Sample(this.TimeSinceStart, this.Resistance, null));
                    this.resistancePacketSamples.Trim(this.TimeSinceStart - 1000, null);
                }
            }
        }


        public XDreamSerialPortServer() : base(XDreamSerialData.CreateResistancePacketStateMachine(), StateUpdatePulseIntervalMilliseconds)
        {
            this.resistanceTimer = new System.Timers.Timer();
            this.resistanceTimer.Interval = ResistanceIntervalMilliseconds;
            this.resistanceTimer.AutoReset = false;
            this.resistanceTimer.Elapsed += ResistanceTimer_Elapsed;
        }

        private void ResistanceTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock(this.resistanceSync)
            {
                
                if (this.resistanceExpires == DateTimeOffset.MaxValue)
                    return;
                double t = (this.resistanceExpires - DateTime.UtcNow).TotalMilliseconds;
                if (t<=0)
                {
                    this.Resistance = 0;
                } 
                else 
                {
                    this.resistanceTimer.Interval = t;
                    this.resistanceTimer.Start();

                }
            }
        }

        protected override void OnSendPacket(out byte[] outputPacket)
        {
            lock (this.stateSync)
                outputPacket = stateBytes;
            
        }

        public override void Dispose()
        {
            base.Dispose();

            this.State = null;
            this.resistanceTimer?.Dispose();
            this.resistanceTimer = null;
        }

    }
}
