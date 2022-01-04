using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Trixter.XDream.API.Communications;

namespace Trixter.XDream.API.Testing
{
    static class XDreamMessageIO
    {

        /// <summary>
        /// Convert an array of bytes into an array of XDreamState objects.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="getTimestamp"></param>
        /// <returns></returns>
        public static XDreamState[] GetStates(byte[] bytes, Func<DateTimeOffset> getTimestamp)
        {
            IPacketStateMachine psm = XDreamSerialData.CreateBikeStatePacketStateMachine();

            List<byte[]> packets = new List<byte[]>();
            List<DateTimeOffset> timestamps = new List<DateTimeOffset>();

            foreach (byte b in bytes)
            {
                if (psm.Add(b) == PacketState.Complete)
                {
                    packets.Add(psm.LastPacket);
                    timestamps.Add(getTimestamp());
                }
            }

            var xbm = packets.Select((p, i) => new XDreamMessage(p, timestamps[i])).ToArray();
            return xbm;
        }
        public static void Write(this BinaryWriter w, XDreamMessage m)
        {
            w.Write(m.TimeStamp.UtcTicks);
            w.Write(m.TimeStamp.Offset.Ticks);
            w.Write(m.RawInput, 0, m.RawInput.Length);
        }

        public static XDreamMessage ReadXDreamMessage(this BinaryReader r)
        {
            DateTimeOffset timestamp = new DateTimeOffset(r.ReadInt64(), new TimeSpan(r.ReadInt64()));
            byte[] bytes = r.ReadBytes(16);

            return new XDreamMessage(bytes, timestamp);
        }

        public static XDreamMessage[] Read(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
                return Read(ms);
        }

        public static XDreamMessage[] Read(Stream s)
        {
            List<XDreamMessage> result = new List<XDreamMessage>();

            using (BinaryReader br = new BinaryReader(s))
                while (s.Position < s.Length)
                    result.Add(br.ReadXDreamMessage());

            return result.ToArray();
        }
    }


}
