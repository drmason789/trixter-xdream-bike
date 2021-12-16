using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Trixter.XDream.API
{
    public delegate void XDreamStateUpdatedDelegate(XDreamClient sender, XDreamState state);

    public class XDreamClient : IDisposable
    {
        public const int MaxResistance = 16;
        public const int MaxBrakePosition = 250;
        public const int MinBrakePosition = 135;
        public const int MaxSteeringPosition = 255;
        public const int CrankPositions = 60;

        private const int resistancePulseInterval = 10;
        private static readonly byte[][] resistanceLevels = new[] {
          new byte[]{0x6a,0x01,0x3d,0x5b,0x79,0x74},
          new byte[]{0x6a,0x11,0x4d,0x6b,0x89,0xd4},
          new byte[]{0x6a,0x21,0x5d,0x7b,0x99,0xf4},
          new byte[]{0x6a,0x31,0x6d,0x8b,0xa9,0x14},
          new byte[]{0x6a,0x41,0x7d,0x9b,0xb9,0x74},
          new byte[]{0x6a,0x51,0x8d,0xab,0xc9,0xd4},
          new byte[]{0x6a,0x61,0x9d,0xbb,0xd9,0xf4},
          new byte[]{0x6a,0x71,0xad,0xcb,0xe9,0x94},
          new byte[]{0x6a,0x81,0xbd,0xdb,0xf9,0x74},
          new byte[]{0x6a,0x91,0xcd,0xeb,0x0a,0xd7},
          new byte[]{0x6a,0xa1,0xdd,0xfb,0x1a,0xf7},
          new byte[]{0x6a,0xb1,0xed,0x0c,0x2a,0x10},
          new byte[]{0x6a,0xc1,0xfd,0x1c,0x3a,0x70},
          new byte[]{0x6a,0xd1,0x0e,0x2c,0x4a,0xd3},
          new byte[]{0x6a,0xe1,0x1e,0x3c,0x5a,0xf3},
          new byte[]{0x6a,0xf1,0x2e,0x4c,0x6a,0x93},
          new byte[]{0x6a,0xff,0x3c,0x5a,0x78,0x8b}};
         

        PortAccessor port;
        PacketStateMachine packetStateMachine;
        int resistanceLevel = 0;
        System.Timers.Timer resistanceTimer;
        

        public bool IsDisposed { get; private set; } = false;
        
        public event XDreamStateUpdatedDelegate StateUpdated;
        
        public int Resistance
        { 
            get => this.resistanceLevel; 
            set
            {
                if (this.IsDisposed)
                    throw new InvalidOperationException();

                this.resistanceLevel = Math.Min(resistanceLevels.Length-1, Math.Max(0, value));

                if (this.resistanceLevel == 0)
                    this.resistanceTimer.Stop();
                else
                    this.resistanceTimer.Start();
            }
        }

        protected virtual void OnStateUpdated(XDreamState message) => this.StateUpdated?.Invoke(this, message);
    
        public XDreamClient()
        {
            this.port = new PortAccessor();
            this.packetStateMachine = new PacketStateMachine();
            this.port.DataReceived += PortReader_DataReceived;
            this.resistanceTimer = new System.Timers.Timer();

            this.resistanceTimer.Interval = resistancePulseInterval;
            this.resistanceTimer.AutoReset = true;
            this.resistanceTimer.Elapsed += (s, e) => this.SendResistance();

        }

        private void PortReader_DataReceived(PortAccessor sender, byte[] bytes)
        {
            for(int i=0; i<bytes.Length; i++)
            {
                if (this.packetStateMachine.Add(bytes[i]) == PacketState.Complete)
                    this.OnStateUpdated(new XDreamMessage(this.packetStateMachine.LastPacket));
            }
        }

        public void Connect(string port)
        {
            this.port.Connect(port);
            this.packetStateMachine.Reset();
            this.Resistance = 0;
        }
                

        public void Disconnect()
        {
            if (this.IsDisposed)
                return;

            this.Resistance = 0;
            this.resistanceTimer.Stop();
            this.port.Disconnect();
        }

        private void SendResistance()
        {
            if(this.port!=null && this.port.IsOpen)
            {
                this.port.Write(resistanceLevels[this.resistanceLevel]);
            }
        }

        public void Dispose()
        {
            this.Disconnect();

            this.resistanceTimer.Dispose();
            this.port.Dispose();

            this.IsDisposed = true;
        }

        public static string [] FindPorts(string [] ports=null)
        {
            if (ports == null)
                ports = SerialPort.GetPortNames() ?? Array.Empty<string>();

            var checks = ports.Select(p=>Task.Factory.StartNew(()=>TryPort(p))).ToArray();
            Task.WaitAll(checks);

            var result = checks.Select((b, i) => new { Success = b.Result, Port = ports[i] }).Where(x => x.Success).Select(x => x.Port).ToArray();
            return result;
        }


        private static bool TryPort(string port)
        {
            List<XDreamState> messages = new List<XDreamState>(100);

            using (XDreamClient xbc = new XDreamClient())
            {
                XDreamStateUpdatedDelegate messageReceived = (s, m) => { messages.Add(m); };

                try
                {
                    xbc.StateUpdated += messageReceived;
                    xbc.Connect(port);
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
