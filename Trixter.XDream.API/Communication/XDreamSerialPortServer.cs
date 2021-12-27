using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trixter.XDream.API
{
    /// <summary>
    /// Implementation of <see cref="XDreamServer"/> that acts as a proxy for a Trixter X-Dream V1 bike over a serial port.
    /// </summary>
    public class XDreamSerialPortServer : XDreamSerialPortBase, XDreamServer
    {
        public const int StateUpdatePulseIntervalMilliseconds = 10;

        /// <summary>
        /// The number of millseconds the requested resitance is sustained.
        /// </summary>
        public const int ResistanceIntervalMilliseconds = 50;

        readonly object resistanceSync = new object();
        int resistanceLevel = 0;
        DateTimeOffset resistanceExpires;

        private readonly object stateSync = new object();
        private XDreamState state;
        private byte[] stateBytes;

        public List<string> packetsReceived = new List<string>();

        private System.Timers.Timer resistanceTimer;

        public event XDreamResistanceChangedDelegate<XDreamServer> ResistanceChanged;

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
            }
        }


        public XDreamSerialPortServer() : base(new ResistancePacketStateMachine(), StateUpdatePulseIntervalMilliseconds)
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

            this.resistanceTimer?.Dispose();
            this.resistanceTimer = null;
        }

    }
}
