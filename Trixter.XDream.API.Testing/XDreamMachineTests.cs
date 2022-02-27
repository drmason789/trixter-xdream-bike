using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class XDreamMachineTests
    {
        [Test]
        public void TestMessagesAreProcessed()
        {
            var xdc = new XDreamTestClient();
            XDreamMachine xdm = XDreamBikeFactory.CreatePremium(xdc);
            List<XDreamState> states = new List<XDreamState>();

            xdm.StateUpdated += (s,e) => states.Add(e);

            var inputMessages = XDreamMessageIO.Read(Resources.flywheel_crank_messages);

            Array.ForEach(inputMessages, xdc.UpdateState);

            // Count the number of states that are expected
            int expected = Math.Min(1, inputMessages.Length);
            for (int i = 1; i < inputMessages.Length; i++)
                if (inputMessages[i].TimeStamp > inputMessages[i - 1].TimeStamp)
                    expected++;


            // Wait for the messages to be processed.
            Thread.Sleep(1000);

            Assert.AreEqual(expected, states.Count);

        }
    }
}
