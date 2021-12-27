using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trixter.XDream.API.Testing
{
    /// <summary>
    /// Uses virtual COM ports configured using com0com (which must be installed) to test message passing between 
    /// the <see cref="PortAccessor"/> objects, and <see cref="XDreamSerialPortClient"/> and <see cref="XDreamSerialPortServer"/>.
    /// </summary>
    [TestFixture]
    internal class ClientServerSerialPortTests
    {
        private const string comA = "COM13";
        private const string comB = "COM14";

        public static bool IsAdministrator =>   new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Assert.NotNull(GetPortPair(), "The virtual COM port pair is not configured.\r\n" +
                "Install com0com and run the " + nameof(InstallPorts) + " \"test\" with Visual Studio elevated to configure it.\r\n" +
                "After that, the tests don't need to be run elevated to use the port pair.\r\n" +
                "Run the " + nameof(UninstallPorts) + " \"test\" elevated to remove the port pair");
        }

        private static Com0Com.CSharp.CrossoverPortPair GetPortPair(Com0Com.CSharp.Com0ComSetupCFacade setupCFacade=null)
        {
            if(setupCFacade==null)
                setupCFacade = new Com0Com.CSharp.Com0ComSetupCFacade();
            return setupCFacade.GetCrossoverPortPairs().FirstOrDefault(p => p.PortNameA == comA && p.PortNameB == comB);
        }

        [Test, Explicit]
        public void InstallPorts()
        {
            Assert.True(IsAdministrator, "Configuring the virtual COM ports requires this code to be run elevated.");

            Com0Com.CSharp.Com0ComSetupCFacade setupCFacade = new Com0Com.CSharp.Com0ComSetupCFacade();

            if(GetPortPair(setupCFacade)==null)
                setupCFacade.CreatePortPair(comA, comB);
        }

        [Test, Explicit]
        public void UninstallPorts()
        {
            Assert.True(IsAdministrator, "Configuring the virtual COM ports requires this code to be run elevated.");

            Com0Com.CSharp.Com0ComSetupCFacade setupCFacade = new Com0Com.CSharp.Com0ComSetupCFacade();

            var pp = GetPortPair(setupCFacade);

            if (pp!=null)
                setupCFacade.DeletePortPair(pp.PairNumber);
        }

        [Test, Explicit]
        public void TestPortAccessor()
        {
            PortAccessor client = new PortAccessor();
            PortAccessor server = new PortAccessor();
            List<byte> received = new List<byte>();
            byte[] testBytes = new byte[] { 1,2,3,4 };

            client.DataReceived += (s, e) => { lock (received) received.AddRange(e); };

            client.Connect(comA);
            server.Connect(comB);

            server.Write(testBytes);

            client.Disconnect();
            server.Disconnect();

            Assert.NotZero(received.Count);
            CollectionAssert.AreEqual(testBytes, received);

        }

        [Test, Explicit]
        public void TestXDreamServerWithPortAccessorClient()
        {
            PortAccessor client = new PortAccessor();
            XDreamSerialPortServer server = new XDreamSerialPortServer();

            List<byte> incoming = new List<byte>();

            client.DataReceived += (s, e) => incoming.AddRange(e);

            XDreamStateBuilder stateBuilder = new XDreamStateBuilder()
            {
                Flywheel = 65534,
                Steering = 120
            };

            client.Connect(comA);
            server.Connect(comB);

            server.State = stateBuilder.ToReadOnly();

            Thread.Sleep(1000);

            client.Disconnect();
            server.Disconnect();

            Assert.NotZero(incoming.Count);

            byte [] basicBytes = XDreamMessage.GetDataPacketTextBytes(stateBuilder);

            for (int i = 0; i < incoming.Count; i++)
                Assert.AreEqual(basicBytes[i % basicBytes.Length], incoming[i]);

        }

        [Test, Explicit]
        public void TestXDreamClientServer()
        {
            XDreamSerialPortClient client = new XDreamSerialPortClient();
            XDreamSerialPortServer server = new XDreamSerialPortServer();

            List<XDreamState> incoming = new List<XDreamState>();

            client.StateUpdated += (s, e) => incoming.Add(e);

            XDreamStateBuilder stateBuilder = new XDreamStateBuilder()
            {
               Flywheel = 65534,
               Steering = 120
            };                       

            client.Connect(comA);
            server.Connect(comB);

            server.State = stateBuilder.ToReadOnly();

            Thread.Sleep(1000);

            client.Disconnect();
            server.Disconnect();

            Assert.NotZero(incoming.Count);

        }

    }
}
