using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class PacketStateMachineTests
    {
        private static readonly Dictionary<PacketState, string> packetStateCodes;
        static PacketStateMachineTests()
        {
            packetStateCodes = new Dictionary<PacketState, string>();
            packetStateCodes.Add(PacketState.None, ".");
            packetStateCodes.Add(PacketState.Invalid, "X");
            packetStateCodes.Add(PacketState.Incomplete, "-");
            packetStateCodes.Add(PacketState.Complete, "C");

        }


        [Test(Description = "A valid packet following a valid packet.")]
        public void ValidPackets()
        {
            TestPacketStateMachine("56b6a0000000000000000000000000000006a0000000000000000000000000000006a",
                                   ".-.---------------------------------C-------------------------------C");
        }

        [Test(Description ="A new packet header is not present in the expected place, no packet header characters in current candidate, so invalidate current and start from next packet heaer characters.")]
        public void InvalidThenPickUpNextValid()
        {
            TestPacketStateMachine("6a0000000000000000000000000000000006a0000000000000000000000000000006a",
                                   "--------------------------------X..---------------------------------C");
        }

        [Test(Description ="Header characters inside a valid packet don't cause confusion.")]
        public void HeaderCharactersInBody()
        {
            TestPacketStateMachine("6a000000000000000000006a000000006a0000000000000000000000000000006a",
                                   "---------------------------------C-------------------------------C");
        }

        [Test(Description ="Reverts to next possible packet header when invalid packet detected.")]
        public void Recovery()
        {
            TestPacketStateMachine("6a0000006a0000000000000000000000000000006a",
                                   "--------------------------------X--------C");
        }

        private void TestPacketStateMachine(string text, string expected)
        {
            PacketStateMachine psm = new PacketStateMachine();

            StringBuilder stringBuilder = new StringBuilder();
            foreach(char c in text)
            {
                var ps = psm.Add((byte)c);
                stringBuilder.Append(packetStateCodes[ps]);
            }


            Assert.AreEqual(expected, stringBuilder.ToString());
        }
    }
}
