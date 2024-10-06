using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using Trixter.XDream.API.Communications;

namespace Trixter.XDream.API.Testing.Communications
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
            TestPacketStateMachine("56b6a00000000000000000000000000016b6a00450000000000000000000000012e6a",
                                   ".-.-------------------------------C-------------------------------C--");
        }

        [Test(Description = "A valid packet following a single char (incomplete byte) followed by a valid packet.")]
        public void OffsetValidPackets()
        {
            TestPacketStateMachine("a6a00000000000000000000000000016b6a00450000000000000000000000012e6a",
                                   ".-------------------------------C-------------------------------C--");
        }

        [Test(Description ="A new packet header is not present in the expected place, no packet header characters in current candidate, so invalidate current and start from next packet heaer characters.")]
        public void InvalidThenPickUpNextValid()
        {
            TestPacketStateMachine("6a0000000000000000000000000000000006a00000000000000000000000000016b6a",
                                   "-------------------------------X...-------------------------------C--");
        }

        [Test(Description ="Header characters inside a valid packet don't cause confusion.")]
        public void HeaderCharactersInBody()
        {
            TestPacketStateMachine("6a000000000000000000006a000000006a00000000000000000000000000016b6a",
                                   "-------------------------------C-------------------------------C--");
        }

        [Test(Description ="Reverts to next possible packet header when invalid packet detected.")]
        public void Recovery()
        {
            TestPacketStateMachine("6a0100006a0200000000000000000000000000686a",
                                   "-------------------------------X-------C--");
        }

        private void TestPacketStateMachine(string text, string expected)
        {
            // Test the test
            Assert.That(text, Is.EqualTo(text.ToLower()), "Text must be lower case.");
                
            IPacketStateMachine psm = XDreamSerialData.CreateBikeStatePacketStateMachine();

            StringBuilder stringBuilder = new StringBuilder();
            foreach(char c in text)
            {
                var ps = psm.Add((byte)c);
                stringBuilder.Append(packetStateCodes[ps]);
            }


            Assert.That(stringBuilder.ToString(), Is.EqualTo(expected));
        }
    }
}
