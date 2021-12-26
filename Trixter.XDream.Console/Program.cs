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

        static bool hadFrontGearUp = false, hadFrontGearDown = false;
        static int deltaR = 0;
        static string comPort;



        static int Main(string[] args)
        {
            comPort = XDreamSerialPort.FindPorts().FirstOrDefault();

            if (string.IsNullOrEmpty(comPort))
            {
                System.Console.WriteLine("Unable to find X-Dream Bike on any COM port.");
                return 1;
            }

            using (XDreamSerialPort port = new XDreamSerialPort())
            {
                XDreamMachine xdm = XDreamBikeFactory.CreatePremium(port);

                xdm.StateUpdated += Xbc_StateUpdated;

                port.Connect(comPort);

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


                port.Disconnect();
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

        private static void Xbc_StateUpdated(XDreamMachine sender, XDreamState e)
        {
            if (e.Buttons.HasFlag(XDreamControllerButtons.FrontGearUp))
            {
                hadFrontGearUp = true;
            }
            else if (hadFrontGearUp)
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

                if (deltaR != 0)
                {
                    sender.Resistance += deltaR;
                    deltaR = 0;
                }

                string flywheelTime = string.Empty;
                if (e.Flywheel < 65534)
                    flywheelTime = (e.Flywheel * 0.1).ToString("0") + "ms";

                sb.AppendLine($"Port              : {comPort}");
                sb.AppendLine($"Steering          : {e.Steering}  / {Constants.MaxSteering}");
                sb.AppendLine($"Left Brake        : {e.LeftBrake} / {Constants.MaxBrake}");
                sb.AppendLine($"Right Brake       : {e.RightBrake} / {Constants.MaxBrake}");
                sb.AppendLine($"Crank Position    : {e.CrankPosition} / {CrankPositions.Positions}");
                sb.AppendLine($"Crank Rev Time    : {e.Crank} (units?)");
                sb.AppendLine($"Crank RPM         : {(sender.CrankMeter.HasData ? sender.CrankMeter.RPM : 0)}");
                sb.AppendLine($"Crank Direction   : {(sender.CrankMeter.HasData ? sender.CrankMeter.Direction : CrankDirection.None)}");
                sb.AppendLine($"Crank Revs        : {sender.TripMeter.CrankRevolutions:0.0}");
                sb.AppendLine($"Flywheel Rev Time : {flywheelTime}");
                sb.AppendLine($"Flywheel Revs     : {sender.TripMeter.FlywheelRevolutions:0.0}");
                sb.AppendLine($"Flywheel RPM      : {sender.FlywheelMeter.RPM} RPM");
                sb.AppendLine($"Heart Rate        : {e.HeartRate}");
                sb.AppendLine($"Buttons           : {e.Buttons}");
                sb.AppendLine($"Resistance        : {sender.Resistance} / {XDreamSerialPort.MaxResistance}");

                System.Console.Clear();
                System.Console.WriteLine(sb.ToString());
            }

        }
    }
}
