using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class MessageStreamTests
    {

        /// <summary>
        /// Tests that the <see cref="PacketStateMachine"/> converts the supplied byte array into the expected
        /// number of packets, and they all convert to <see cref="XDreamMessage"/> objects without error.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="expectedNumberOfPackets"></param>
        private void TestBytes(byte [] bytes, int expectedNumberOfPackets)
        {
            PacketStateMachine psm = new PacketStateMachine();

            List<byte[]> packets = new List<byte[]>();
            List<DateTimeOffset> timestamps = new List<DateTimeOffset>();

            foreach (byte b in bytes)
            {
                if (psm.Add(b) == PacketState.Complete)
                {
                    packets.Add(psm.LastPacket);
                    timestamps.Add(DateTimeOffset.Now);
                }
            }

            Assert.AreEqual(expectedNumberOfPackets, packets.Count);

            var xbm = packets.Select((p, i) => new XDreamMessage(p, timestamps[i])).ToArray();

            Assert.AreEqual(expectedNumberOfPackets, xbm.Length);
        }

        [Test(Description ="Test with input from flywheel, brakem steering, crank and button inputs.")]
        public void TestGeneral() => TestBytes(Resources.input, 4586);


        [Test(Description ="Test with input focussed on heart rate data.")]
        public void HeartRate() => TestBytes(Resources.heartrate, 4587);


        [Test(Description ="Test with input from pressing all buttons on the controller sequentially.")]
        public void Buttons() => TestBytes(Resources.buttons, 4586);
        
    }
}
