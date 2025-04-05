using System;

namespace Trixter.XDream.API.Communications
{
    public abstract class XDreamSerialPortBase : IDisposable
    {
              
        PortAccessor port;        
        IPacketStateMachine packetStateMachine;
        System.Timers.Timer messageTimer;

        public int MessagePulseIntervalMilliseconds { get; private set; }

        public bool IsDisposed { get; private set; } = false;

        protected bool MessageTimerEnabled { get => this.messageTimer.Enabled; set => this.messageTimer.Enabled=value; }

        /// <summary>
        /// Override to do something with an incoming packet.
        /// </summary>
        /// <param name="packet"></param>
        protected abstract void OnPacketReceived(byte[] packet);

        /// <summary>
        /// Override to set the outgoing packet.
        /// </summary>
        /// <param name="outputPacket">The outgoing data packet. Set to null to send nothing.</param>
        protected abstract void OnSendPacket(out byte [] outputPacket);

        protected virtual void BeforeDisconnect() { }
        protected virtual void AfterConnect() { }

        internal XDreamSerialPortBase(IPacketStateMachine packetStateMachine, int messagePulseIntervalMilliseconds)
        {
            this.port = new PortAccessor();
            this.packetStateMachine = packetStateMachine;
            this.port.DataReceived += PortReader_DataReceived;

            this.MessagePulseIntervalMilliseconds = messagePulseIntervalMilliseconds;

            this.messageTimer = new System.Timers.Timer();
            this.messageTimer.Interval = messagePulseIntervalMilliseconds;
            this.messageTimer.AutoReset = true;
            this.messageTimer.Elapsed += (s, e) => 
            {
                this.OnSendPacket(out var outputPacket);
                if (outputPacket?.Length > 0)
                    this.Send(outputPacket);
            };
        }

        private void PortReader_DataReceived(PortAccessor sender, byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                if (this.packetStateMachine.Add(bytes[i]) == PacketState.Complete)
                {
                    this.OnPacketReceived(this.packetStateMachine.LastPacket);
                }
            }
        }

        public void Connect(string port)
        {
            this.port.Connect(port);
            this.packetStateMachine.Reset();

            this.AfterConnect();
        }

        public void Disconnect()
        {
            if (this.IsDisposed)
                return;

            this.BeforeDisconnect();

            this.messageTimer.Stop();
            this.port.Disconnect();
        }

        protected void Send(byte [] bytes)
        {
            if (bytes!=null && bytes.Length!=0 && this.port != null && this.port.IsOpen)
            {
                try
                {
                    this.port.Write(bytes);
                }
                catch(InvalidOperationException)
                {
                    // The port has probably closed since the above check, ignore
                }
            }
        }

        public virtual void Dispose()
        {
            this.Disconnect();

            this.messageTimer?.Dispose();
            this.port?.Dispose();

            this.messageTimer = null;
            this.port = null;

            this.IsDisposed = true;
        }
    }
}
