using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trixter.XDream.API
{

    /// <summary>
    /// State machine for packets that arrive as text encoded hexadecimal numbers.
    /// </summary>
    internal class TextBytesPacketStateMachine : IPacketStateMachine
    {       
        private List<byte> bytes = new List<byte>(XDreamMessage.MessageSize);
        private int messageSize;
        private BytePacketStateMachine innerStateMachine;
        private string header;

        public byte[] LastPacket { get; private set; }
      

        /// <summary>
        /// Constructor.
        /// </summary>
        public TextBytesPacketStateMachine(byte header, int messageSize)
        {
            this.messageSize = messageSize;
            this.header = header.ToString("x2");
            this.innerStateMachine = new BytePacketStateMachine(XDreamSerialData.MessageHeader, this.messageSize / 2);
        }

        public void Reset()
        {
            this.bytes.Clear();            
        }

        public PacketState Add(byte b)
        {

            char c = (char)b;

            if(!char.IsDigit(c) && !(c>='a' && c<='f'))
            {
                this.Reset();
                return PacketState.Invalid;
            }

            this.bytes.Add(b);

            // Look for the header
            if (this.bytes.Count<3)
            {
                while (this.bytes.Count > 0 && this.bytes[0] != this.header[0] || this.bytes.Count>1 && this.bytes[1]!=this.header[1]) 
                    this.bytes.RemoveAt(0);

                return this.bytes.Count>0 ? PacketState.Incomplete:PacketState.None;
            }

            if(this.bytes.Count==this.messageSize)
            {
                this.innerStateMachine.Reset();

                // feed it to the inner packet state machine and see what it says
                string packet = Encoding.ASCII.GetString(this.bytes.ToArray());

                for (int i = 0, j = 0; i < packet.Length; i += 2, j++)
                {
                    string substring = packet.Substring(i, 2);
                    byte value = (byte)int.Parse(substring, System.Globalization.NumberStyles.HexNumber);
                    var result = this.innerStateMachine.Add(value);

                    if (result == PacketState.Complete)
                    {
                        this.LastPacket = this.innerStateMachine.LastPacket;
                        this.Reset();
                        return result;
                    }
                    else if (result!=PacketState.Incomplete)
                    {
                        // Move to the next potential packet
                        int nextHeader = packet.IndexOf(this.header, 2);
                        if (nextHeader > 0)
                            this.bytes.RemoveRange(0, nextHeader);
                        else
                            this.Reset();

                        return PacketState.Invalid;
                    }
                }
            }

            return PacketState.Incomplete;

        }

       
    }
}
