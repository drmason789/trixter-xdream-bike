using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API
{
    internal class XDreamSerialData
    {
        public const byte MessageHeader = 0x6a;
        public const string MessageHeaderText = "6a";

        public const int MaxResistance = 250;

        public const int ResistancePacketLength = 6;

        private static byte [] CalculateResistancePacket(int level)
        {
            if (level < 0 || level > MaxResistance) throw new ArgumentOutOfRangeException(nameof(level));
            byte[] packet = new byte[] { MessageHeader, (byte)level, (byte)((level + 60) % 255), (byte)((level + 90) % 255), (byte)((level + 120) % 255), 0 };
            packet[packet.Length - 1] = packet.Aggregate((a, b) => (byte)(a ^ b));
            return packet;
        }

        public static readonly IReadOnlyList<byte[]> ResistanceLevels =
            Enumerable.Range(0, MaxResistance+1).Select(i => CalculateResistancePacket(i)).ToList();

        public static IPacketStateMachine CreateBikeStatePacketStateMachine() => new TextBytesPacketStateMachine(MessageHeader, XDreamMessage.MessageSize);
        public static IPacketStateMachine CreateResistancePacketStateMachine() => new BytePacketStateMachine(MessageHeader, ResistancePacketLength);    
                             
    }
}
