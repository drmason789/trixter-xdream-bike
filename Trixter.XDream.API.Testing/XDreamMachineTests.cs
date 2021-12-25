using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Trixter.XDream.API.Testing
{
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

            // Wait for the messages to be processed.
            Thread.Sleep(1000);

            Assert.AreEqual(inputMessages.Length, states.Count);

        }
    }
    

}
