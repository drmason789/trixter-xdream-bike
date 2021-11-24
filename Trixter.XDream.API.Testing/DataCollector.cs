using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace Trixter.XDream.API.Testing
{
    [TestFixture]
    public class DataCollector
    {
        /// <summary>
        /// Run this to collect data to store for tests.
        /// </summary>
        [Test, Explicit]
        public void Collect()
        {
            string defaultPort = "COM2";

            List<byte[]> blocks = new List<byte[]>();

            using (PortAccessor pa = new PortAccessor())
            {
                pa.DataReceived += (sender, bytes) => blocks.Add(bytes);
                pa.Connect(defaultPort);

                Thread.Sleep(60000);
            }

            byte[] allBytes = blocks.SelectMany(x => x).ToArray();
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            System.IO.File.WriteAllBytes(Path.Combine(desktop, "input.bin"), allBytes);

        }

        
    }
}
