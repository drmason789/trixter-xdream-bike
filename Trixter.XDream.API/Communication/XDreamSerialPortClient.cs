using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Trixter.XDream.API
{
    /// <summary>
    /// Implementation of <see cref="XDreamClient"/> that interacts with a real Trixter X-Dream V1 bike over a serial port.
    /// </summary>
    public class XDreamSerialPortClient : XDreamSerialPortBase, XDreamClient
    {
        
        public const int ResistancePulseIntervalMilliseconds = 10;
        
        int resistanceLevel = 0;                      
       
        public event XDreamStateUpdatedDelegate<XDreamClient> StateUpdated;
        
        public int Resistance
        { 
            get => this.resistanceLevel; 
            set
            {
                if (this.IsDisposed)
                    throw new InvalidOperationException();

                this.resistanceLevel = Math.Min(XDreamSerialData.ResistanceLevels.Length-1, Math.Max(0, value));

                if (this.resistanceLevel == 0)
                    this.MessageTimerEnabled = false;
                else
                    this.MessageTimerEnabled = true;
            }
        }

        protected virtual void OnStateUpdated(XDreamState message) => this.StateUpdated?.Invoke(this, message);

        protected override void OnPacketReceived(byte[] packet) => this.OnStateUpdated(new XDreamMessage(packet));
        

        public XDreamSerialPortClient() : base(new PacketStateMachine(), ResistancePulseIntervalMilliseconds)
        {

        }

        protected override void AfterConnect()
        {
            base.AfterConnect();

            this.Resistance = 0;
        }

        protected override void BeforeDisconnect()
        {
            base.BeforeDisconnect();

            this.Resistance = 0;
        }

        protected override void OnSendPacket(out byte [] outputPacket)
        {
            outputPacket = XDreamSerialData.ResistanceLevels[this.resistanceLevel];
        }

        /// <summary>
        /// Locates the serial ports in the computer that appear to have an X-Dream bike attached and delivering valid data.
        /// </summary>
        /// <param name="ports"></param>
        /// <returns></returns>
        public static string[] FindPorts(string[] ports = null)
        {
            if (ports == null)
                ports = SerialPort.GetPortNames() ?? Array.Empty<string>();

            var checks = ports.Select(p => System.Threading.Tasks.Task.Factory.StartNew(() => TryPort(p))).ToArray();
            Task.WaitAll(checks);

            var result = checks.Select((b, i) => new { Success = b.Result, Port = ports[i] }).Where(x => x.Success).Select(x => x.Port).ToArray();
            return result;
        }


        private static bool TryPort(string portName)
        {
            if (string.IsNullOrWhiteSpace(portName))
                return false;

            List<XDreamState> messages = new List<XDreamState>(100);

            using (XDreamSerialPortClient port = new XDreamSerialPortClient())
            {
                try
                {
                    port.StateUpdated += (s, m) => messages.Add(m);
                    port.Connect(portName);
                    Thread.Sleep(1000);

                }
                catch (Exception)
                {
                    // just keep trying
                    // TODO: add some sort of error state property to report this
                }


            }
            return messages.Count > 0;
        }

    }
}
