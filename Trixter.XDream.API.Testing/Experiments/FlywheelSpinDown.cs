using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Trixter.XDream.API;

namespace Trixter.XDream.API.Testing
{
    [TestFixture, Explicit]
    public class FlywheelSpinDown
    {
        /// <summary>
        /// Run this to collect data to store for tests. Start the test, then spin the flywheel up to 700 RPM, at least to get a reading of sub-1000.
        /// Then let it spin down to stop.
        /// </summary>
        [Test, Explicit]
        public void CollectMessages()
        {
            // Note to developer: configure these temporarily to suit your local setup and goal
            string defaultPort = "COM2";
            string outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "flywheel-spindown.messages.bin");
            
            // --------------------------------------------------------------------------------------------------------------------------

            List<XDreamState> messages = new List<XDreamState>();

            bool seenFast = false, finished = false;

            using (var xbc = new XDreamSerialPort())
            {

                //XDreamStateMonitor monitor = new XDreamStateMonitor { Filter=XDreamStateChanges.Flywheel };
                //monitor.Change += (s,m)=>messages.Add(m.State);
                xbc.StateUpdated += (s, m) => { messages.Add(m); };
                xbc.Connect(defaultPort);

                while (!finished)
                {
                    Thread.Sleep(100);
                    if (messages.Count > 0)
                    {
                        var last = messages[messages.Count - 1];


                        if (!seenFast && last.Flywheel < 1000)
                            seenFast = true;

                        if (seenFast)
                            if (last.Flywheel > 65530)
                                finished = true;
                    }

                }
            }

            messages = messages.SkipWhile(m => m.Flywheel > 1000).ToList();

            using (FileStream fs = File.Create(outputFilePath))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                foreach (var m in messages.Cast<XDreamMessage>())
                    bw.Write(m);
            }

        }


        [Test]
        public void PerformSpindownAnalysis()
        {
            var messages = XDreamMessageIO.Read(Resources.flywheel_spindown_messages);

            XDreamState last = messages[0];
            DateTimeOffset t0 = last.TimeStamp;
            List<KeyValuePair<double, int>> changes = new List<KeyValuePair<double, int>>();


            foreach(var message in messages.Skip(1))
            {
                if(message.Flywheel!=last.Flywheel)
                {
                    changes.Add(new KeyValuePair<double, int>(message.TimeStamp.Subtract(t0).TotalMilliseconds, message.Flywheel));
                }

                last = message;
            }
                       

            for(int i=1; i<changes.Count; i++)
            {
                double dt = changes[i].Key - changes[i - 1].Key;
                double rpm = 60000d / dt;

                System.Console.WriteLine($"{changes[i].Value},{rpm:0},{dt:0.000}");

            }
        }

    }
}
