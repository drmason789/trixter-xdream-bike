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

        readonly object resistanceSync = new object();
        int resistanceLevel = 0;

        private readonly object stateSync = new object();
        private XDreamState state;
        private byte[] stateBytes;

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
                }

                if (changed) this.OnResistanceChanged();
            }
        }

        protected virtual void OnResistanceChanged() => this.ResistanceChanged?.Invoke(this);

        protected override void OnPacketReceived(byte[] packet)
        {
            if(packet?.Length==XDreamSerialData.ResistancePacketLength)
            {
                this.Resistance= packet[1]/16;
            }
        }


        public XDreamSerialPortServer() : base(2*XDreamSerialData.ResistancePacketLength, StateUpdatePulseIntervalMilliseconds)
        {

        }

        protected override void OnSendPacket(out byte[] outputPacket)
        {
            lock (this.stateSync)
                outputPacket = stateBytes;
            
        }
             

    }
}
