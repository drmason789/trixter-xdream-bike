using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Trixter.XDream.API;
using Trixter.XDream.API.Communications;
using Trixter.XDream.API.Flywheel;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.API.Testing.Experimental
{
    [TestFixture, Explicit]
    public class FlywheelSpinDown
    {
        /// <summary>
        /// Run this to collect data to store for tests.
        ///
        /// - Start the test
        /// - Wait for the double beep.
        /// - Spin the flywheel up to 800 RPM, at least to get a reading of sub-800.
        /// - Stop pedalling and hold the red button for 1s. The test should detect this, set the resistance.
        /// - Then let the flywheel spin down to 0RPM and wait for the single lower pitched beep. Keep the pedals still.
        /// 
        /// </summary>
        [Test, Explicit]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(50)]
        [TestCase(60)]
        [TestCase(70)]
        [TestCase(80)]
        [TestCase(90)]
        [TestCase(100)]
        [TestCase(110)]
        [TestCase(120)]
        [TestCase(130)]
        [TestCase(140)]
        [TestCase(150)]
        [TestCase(160)]
        [TestCase(170)]
        [TestCase(180)]
        [TestCase(190)]
        [TestCase(200)]
        [TestCase(210)]
        [TestCase(220)]
        [TestCase(230)]
        [TestCase(240)]
        [TestCase(250)]
        public void CollectMessages(int resistance = 0)
        {
            // Note to developer: configure these temporarily to suit your local setup and goal
            string defaultPort = "COM4";
            string outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), $"trixter-xdream\\flywheel-spindown.messages.R{resistance:D3}.bin");

            // --------------------------------------------------------------------------------------------------------------------------

            List<XDreamState> messages = new List<XDreamState>();

            Console.Beep(1500, 2000);

            bool seenFast = false, finished = false;
            bool seenRed = false;
            using (var xbc = new XDreamSerialPortClient())
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

                        if (!seenRed)
                            seenRed = last.Red;
                        if (!seenRed)
                            continue;


                        if (!seenFast && last.Flywheel < 1000)
                        {
                            seenFast = true;

                            xbc.Resistance = resistance;
                        }

                        if (seenFast)
                        {

                            if (last.Flywheel > 65530)
                                finished = true;
                    }
                    }

                }
            }

            Console.Beep(1000,2000);

            messages = messages.SkipWhile(m => m.Flywheel > 1000).ToList();

            string directoryName = Path.GetDirectoryName(outputFilePath);
            Directory.CreateDirectory(directoryName);

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


            foreach (var message in messages.Skip(1))
            {
                if (message.Flywheel != last.Flywheel)
                {
                    changes.Add(new KeyValuePair<double, int>(message.TimeStamp.Subtract(t0).TotalMilliseconds, message.Flywheel));
                }

                last = message;
            }


            for (int i = 1; i < changes.Count; i++)
            {
                double dt = changes[i].Key - changes[i - 1].Key;
                double rpm = 60000d / dt;

                System.Console.WriteLine($"{changes[i].Value},{rpm:0},{dt:0.000}");

            }
        }

    }

}
