using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class MessageStreamTests
    {
        [Test]
        public void Test()
        {
            PacketStateMachine psm = new PacketStateMachine();

            List<byte[]> packets = new List<byte[]>();
            List<DateTimeOffset> timestamps = new List<DateTimeOffset>();

            foreach(byte b in Resources.input)
            {
                if (psm.Add(b) == PacketState.Complete)
                {
                    packets.Add(psm.LastPacket);
                    timestamps.Add(DateTimeOffset.Now);
                }
            }

            Assert.AreEqual(4586, packets.Count);

            var xbm = packets.Select((p, i) => new XDreamMessage(p, timestamps[i])).ToArray();

            Assert.AreEqual(4586, xbm.Length);
                       

        }


        [Test]
        public void HeartRate()
        {
            PacketStateMachine psm = new PacketStateMachine();

            List<byte[]> packets = new List<byte[]>();
            List<DateTimeOffset> timestamps = new List<DateTimeOffset>();

            foreach (byte b in Resources.heartrate)
            {
                if (psm.Add(b) == PacketState.Complete)
                {
                    packets.Add(psm.LastPacket);
                    timestamps.Add(DateTimeOffset.Now);
                }
            }

            Assert.AreEqual(4587, packets.Count);

            var xbm = packets.Select((p, i) => new XDreamMessage(p, timestamps[i])).ToArray();

            Assert.AreEqual(4587, xbm.Length);
        }


        [Test]
        public void Buttons()
        {
            PacketStateMachine psm = new PacketStateMachine();

            List<byte[]> packets = new List<byte[]>();
            List<DateTimeOffset> timestamps = new List<DateTimeOffset>();

            foreach (byte b in Resources.buttons)
            {
                if (psm.Add(b) == PacketState.Complete)
                {
                    packets.Add(psm.LastPacket);
                    timestamps.Add(DateTimeOffset.Now);
                }
            }

            Assert.AreEqual(4586, packets.Count);

            var xbm = packets.Select((p, i) => new XDreamMessage(p, timestamps[i])).ToArray();

            Assert.AreEqual(4586, xbm.Length);

            
        }
    }
}
