using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API
{
    internal class ResistancePacketStateMachine : IPacketStateMachine
    {
        private enum State
        {
            HeaderChar0,
            Body,
            NextHeaderChar0,
        }

        List<byte> bytes = new List<byte>(2 * XDreamSerialData.ResistancePacketLength);
        int nextPossiblePacketHeader = 0;
        State state = State.HeaderChar0;
        byte header;
        private int messageSize;

        public byte[] LastPacket { get; private set; }
       

        /// <summary>
        /// Constructor.
        /// </summary>
        public ResistancePacketStateMachine()
        {
            this.messageSize = XDreamSerialData.ResistancePacketLength;
            this.header = XDreamSerialData.MessageHeader;
        }

        public void Reset()
        {
            this.bytes.Clear();
            this.nextPossiblePacketHeader = 0;
            this.state = State.HeaderChar0;
        }

        public PacketState Add(byte b)
        {
            if (this.state == State.HeaderChar0)
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
                if (this.bytes.Count >= this.messageSize)
                {
                    this.state = State.NextHeaderChar0;
                }

                if (this.nextPossiblePacketHeader == 0 && this.bytes[this.bytes.Count - 1] == this.header)
                    this.nextPossiblePacketHeader = this.bytes.Count - 1;

                return PacketState.Incomplete;
            }

            if (state == State.NextHeaderChar0)
            {
                this.bytes.Add(b);
                if (b == this.header)
                {
                    this.LastPacket = this.bytes.Take(this.messageSize).ToArray();
                    this.nextPossiblePacketHeader = this.bytes.Count - 1;
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
            if (this.nextPossiblePacketHeader > 0)
            {
                // delete the bytes before the next possible header 
                this.bytes.RemoveRange(0, nextPossiblePacketHeader);
                this.nextPossiblePacketHeader = 0;
                this.state = State.Body;
            }
            else
            {
                this.state = State.HeaderChar0;
                this.bytes.Clear();

            }
        }
    }
}
