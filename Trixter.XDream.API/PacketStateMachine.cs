using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API
{
    internal class PacketStateMachine
    {
        private enum State
        {
            HeaderChar0,
            HeaderChar1,
            Body,
            NextHeaderChar0,
            NextHeaderChar1
        }

        List<byte> bytes = new List<byte>(XDreamMessage.MessageSize*2);
        int nextPossiblePacketHeader = 0;
        State state = State.HeaderChar0;
        byte[] lastPacket=null;

        public byte[] LastPacket
        {
            get
            {
                if (this.lastPacket == null)
                    return null;
                if (this.lastPacket.Length == XDreamMessage.MessageSize)
                {
                    string packet = new string(this.lastPacket.Select(b=>(char)b).ToArray());
                    byte[] newArray = new byte[this.lastPacket.Length / 2];
                    for (int i = 0, j = 0; i < this.lastPacket.Length; i += 2, j++)
                        newArray[j] = (byte)int.Parse(packet.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                    this.lastPacket = newArray;
                }
                return this.lastPacket;
            }
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
                // Looking for the first character of
                if(b==XDreamMessage.MessageHeader[0])
                {
                    this.state = State.HeaderChar1;
                    this.bytes.Add(b);
                    return PacketState.Incomplete;
                }
                return PacketState.None;
            }

            if(state==State.HeaderChar1)
            {
                if(b==XDreamMessage.MessageHeader[1])
                {
                    this.state = State.Body;
                    this.bytes.Add(b);
                    return PacketState.Incomplete;
                }
                this.state = 0;
                this.bytes.Clear();
                return PacketState.None;
            }

            if(state==State.Body)
            {
                this.bytes.Add(b);
                if (this.bytes.Count>=XDreamMessage.MessageSize)
                {
                    this.state = State.NextHeaderChar0;
                }

                if (this.nextPossiblePacketHeader ==0 && this.bytes[this.bytes.Count - 1] == XDreamMessage.MessageHeader[1] && this.bytes[this.bytes.Count - 2] == XDreamMessage.MessageHeader[0])
                    this.nextPossiblePacketHeader = this.bytes.Count - 2;

                return PacketState.Incomplete;
            }

            if(state==State.NextHeaderChar0)
            {
                this.bytes.Add(b);
                if (b == XDreamMessage.MessageHeader[0])
                {
                    this.state = State.NextHeaderChar1;
                    return PacketState.Incomplete;
                }

                // Unexpected character - this is not a proper packet
                this.NextHeader();
                return PacketState.Invalid;
            }

            if (state == State.NextHeaderChar1)
            {
                this.bytes.Add(b);
                if (b == XDreamMessage.MessageHeader[1])
                {
                    this.lastPacket = this.bytes.Take(XDreamMessage.MessageSize).ToArray();
                    this.nextPossiblePacketHeader = this.bytes.Count - 2;
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
            if(this.nextPossiblePacketHeader >0)
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
