﻿using System;
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
                Thread.Sleep(1000*sampleLengthSeconds);
            }

            byte[] allBytes = blocks.SelectMany(x => x).ToArray();
            
            System.IO.File.WriteAllBytes(outputFilePath, allBytes);
        }

        
    }
}
