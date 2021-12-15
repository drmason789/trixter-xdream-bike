using System;
using System.Linq;
using System.Text;
using Trixter.XDream.API;

namespace Trixter.XDream.Console
{
    class Program
    {
        const int updateInterval = 1000;
        const int timeout = 1500;

        // thread sync object for console and lastUpdate value
        static object sync = new object();
        static DateTime lastUpdate = DateTime.MinValue;

        static bool hadFrontGearUp=false, hadFrontGearDown=false;
        static int deltaR = 0;
        static string comPort;

        static int Main(string[] args)
        {
            comPort = XDreamClient.FindPorts().FirstOrDefault();

            if(string.IsNullOrEmpty(comPort))
            {
                System.Console.WriteLine("Unable to find X-Dream Bike on any COM port.");
                return 1;
            }

            using (XDreamClient xbc = new XDreamClient())
            {
                xbc.MessageReceived += Xbc_MessageReceived;

                xbc.Connect(comPort);

                System.Console.Title = "X-Dream Bike Diagnostic Utility";

                using (System.Timers.Timer clsTimer = new System.Timers.Timer())
                {
                    clsTimer.Interval = Math.Max(updateInterval, timeout / 2);
                    clsTimer.AutoReset = true;
                    clsTimer.Elapsed += ClsTimer_Elapsed;
                    clsTimer.Start();

                    System.Console.ReadLine();
                    clsTimer.Stop();
                }


                xbc.Disconnect();
            }

            return 0;
        }

        private static void ClsTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (sync)
            {
                if (DateTime.Now.Subtract(lastUpdate).TotalMilliseconds >= timeout)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine($"Port              : {comPort}");
                    sb.AppendLine($"Last Update       : {lastUpdate:U}");

                    System.Console.Clear();
                    System.Console.WriteLine(sb.ToString());
                }
            }
        }

        private static void Xbc_MessageReceived(object sender, XDreamMessage e)
        {

            if (e.Buttons.HasFlag(XDreamControllerButtons.FrontGearUp))
            {
                hadFrontGearUp = true;
            }
            else if(hadFrontGearUp)
            {
                deltaR++;
                hadFrontGearUp = false;
            }

            if (e.Buttons.HasFlag(XDreamControllerButtons.FrontGearDown))
                hadFrontGearDown = true;
            else if (hadFrontGearDown)
            {
                deltaR--;
                hadFrontGearDown = false;
            }

            lock (sync)
            {
                if (DateTime.Now.Subtract(lastUpdate).TotalMilliseconds < updateInterval)
                    return;
                lastUpdate = DateTime.Now;


                StringBuilder sb = new StringBuilder();
                XDreamClient xbc = (XDreamClient)sender;

                if (deltaR != 0)
                {
                    xbc.Resistance += deltaR;
                    deltaR = 0;
                }

                sb.AppendLine($"Port              : {comPort}");
                sb.AppendLine($"Steering          : {e.Steering}  / {XDreamClient.MaxSteeringPosition}");
                sb.AppendLine($"Left Brake        : {e.LeftBrake} / {XDreamClient.MaxBrakePosition}");
                sb.AppendLine($"Right Brake       : {e.RightBrake} / {XDreamClient.MaxBrakePosition}");
                sb.AppendLine($"Crank Position    : {e.CrankPosition} / {XDreamClient.CrankPositions}");
                sb.AppendLine($"Crank Speed       : {e.Crank} : {e.CrankRPM} RPM");
                sb.AppendLine($"Flywheel Speed    : {e.Flywheel} : {e.FlywheelRPM} RPM");
                sb.AppendLine($"Heart Rate        : {e.HeartRate}");
                sb.AppendLine($"Buttons           : {e.Buttons}");
                sb.AppendLine($"Resistance        : {(sender as XDreamClient)?.Resistance} / {XDreamClient.MaxResistance}");

                System.Console.Clear();
                System.Console.WriteLine(sb.ToString());
            }

        }
    }
}
