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
        /// Tests that the <see cref="TextBytesPacketStateMachine"/> converts the supplied byte array into the expected
        /// number of packets, and they all convert to <see cref="XDreamState"/> objects without error.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="expectedNumberOfPackets"></param>
        private void TestBytes(byte [] bytes, int expectedNumberOfPackets)
        {
            var xbm = XDreamMessageIO.GetStates(bytes, ()=>DateTimeOffset.UtcNow);

            Assert.AreEqual(expectedNumberOfPackets, xbm.Length);
        }

        [Test(Description ="Test with input from flywheel, brake and steering, crank and button inputs.")]
        public void TestGeneral() => TestBytes(Resources.input, 4587);


        [Test(Description ="Test with input focussed on heart rate data.")]
        public void HeartRate() => TestBytes(Resources.heartrate, 4588);


        [Test(Description ="Test with input from pressing all buttons on the controller sequentially.")]
        public void Buttons() => TestBytes(Resources.buttons, 4587);

       
    }


    

}
