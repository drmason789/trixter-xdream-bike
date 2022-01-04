using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using NUnit.Framework;
using Trixter.XDream.API.Communications;

namespace Trixter.XDream.API.Testing.Experimental
{
    [TestFixture]
    public class DataCollector
    {
        /// <summary>
        /// Run this to collect data to store for tests.
        /// </summary>
        [Test, Explicit]
        public void CollectRawData()
        {
            // Note to developer: configure these temporarily to suit your local setup and goal
            string defaultPort = "COM2";
            string outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "input.bin");
            int sampleLengthSeconds = 60;
            // --------------------------------------------------------------------------------------------------------------------------

            List<byte[]> blocks = new List<byte[]>();

            using (PortAccessor pa = new PortAccessor())
            {
                pa.DataReceived += (sender, bytes) => blocks.Add(bytes);
                pa.Connect(defaultPort);

                // Wait the specified time for the input to load into the block list.
                Thread.Sleep(1000 * sampleLengthSeconds);
            }

            byte[] allBytes = blocks.SelectMany(x => x).ToArray();

            System.IO.File.WriteAllBytes(outputFilePath, allBytes);
        }

        /// <summary>
        /// Run this to collect data to store for tests.
        /// </summary>
        [Test, Explicit]
        public void CollectMessages()
        {
            // Note to developer: configure these temporarily to suit your local setup and goal
            string defaultPort = "COM2";
            string outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "input-messages.bin");
            int sampleLengthSeconds = 60;
            // --------------------------------------------------------------------------------------------------------------------------

            List<XDreamState> messages = new List<XDreamState>();

            using (var xbc = new XDreamSerialPortClient())
            {
                xbc.StateUpdated += (s, m) => { messages.Add(m); }; ;
                xbc.Connect(defaultPort);

                // Wait the specified time for the input to load into the block list.
                Thread.Sleep(1000 * sampleLengthSeconds);
            }

            using (FileStream fs = File.Create(outputFilePath))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                foreach (var m in messages.Cast<XDreamMessage>())
                    bw.Write(m);
            }

        }





    }


}
