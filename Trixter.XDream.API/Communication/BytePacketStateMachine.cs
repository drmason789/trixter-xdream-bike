using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API.Communications
{

    /// <summary>
    /// State machine for packets that arrive as bytes.
    /// </summary>
    internal class BytePacketStateMachine : IPacketStateMachine
    {
        List<byte> bytes = new List<byte>();
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
            this.bytes = new List<byte>(packetLength);

            this.Reset();
        }

        public void Reset()
        {
            this.bytes.Clear();
        }

        public PacketState Add(byte b)
        {
            if (this.bytes.Count == 0 && b != this.header)
                return PacketState.None;

            this.bytes.Add(b);

            if (bytes.Count < this.messageSize)
                return PacketState.Incomplete;

            byte checksum = this.bytes.Take(this.messageSize - 1).Aggregate((b0, b1) => (byte)(b0 ^ b1));
            if (b == checksum)
            {
                this.LastPacket = this.bytes.ToArray();
                this.bytes.Clear();
                return PacketState.Complete;
            }

            // Unexpected character - this is not a proper packet               
            // Look for the next header character, starting after the first one, of course.
            int nextHeader = this.bytes.IndexOf(this.header, 1);

            if (nextHeader > 0)
                // delete the bytes before the next possible header 
                this.bytes.RemoveRange(0, nextHeader);
            else
                this.bytes.Clear();

            return PacketState.Invalid;
        }

    }
}
