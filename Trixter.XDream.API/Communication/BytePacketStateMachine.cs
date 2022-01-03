using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API
{

    /// <summary>
    /// State machine for packets that arrive as bytes.
    /// </summary>
    internal class BytePacketStateMachine : IPacketStateMachine
    {
        private enum State
        {
            Header,
            Body,
            Checksum
        }

        List<byte> bytes = new List<byte>();
        
        State state = State.Header;
        byte header;
        private int messageSize;

        public byte[] LastPacket { get; private set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        public BytePacketStateMachine(byte headerByte, int packetLength)
        {
            this.messageSize = packetLength;
            this.header = headerByte;
            this.bytes = new List<byte>();

            this.Reset();
        }

        public void Reset()
        {
            this.bytes.Clear();
            this.state = State.Header;
        }

        public PacketState Add(byte b)
        {
            if (this.state == State.Header)
            {
                if (b == this.header)
                {
                    this.state = State.Body;
                    this.bytes.Add(b);
                    return PacketState.Incomplete;
                }
                this.state = 0;
                this.bytes.Clear();
                return PacketState.None;
            }


            if (state == State.Body)
            {
                this.bytes.Add(b);

                if (this.bytes.Count == this.messageSize-1)
                    this.state = State.Checksum;                

                return PacketState.Incomplete;
            }

            if (state == State.Checksum)
            {
                this.bytes.Add(b);
                byte checksum = this.bytes.Take(this.messageSize - 1).Aggregate((b0,b1) => (byte)(b0^b1));
                if (b == checksum)
                {
                    this.LastPacket = this.bytes.Take(this.messageSize).ToArray();
                    this.NextHeader();
                    return PacketState.Complete;
                }

                // Unexpected character - this is not a proper packet                
                this.NextHeader();
                return PacketState.Invalid;
            }

            throw new InvalidOperationException("Object is in invalid state.");
        }

        private void NextHeader()
        {
            int nextHeader = this.bytes.IndexOf(this.header, 1);

            if (nextHeader > 0)
                // delete the bytes before the next possible header 
                this.bytes.RemoveRange(0, nextHeader);
            else
                this.bytes.Clear();

            this.state = this.bytes.Count > 0 ? State.Body : State.Header;
        }
    }
}
