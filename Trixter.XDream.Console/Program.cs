using System;
using System.Linq;
using System.Text;
using Trixter.XDream.API;

namespace Trixter.XDream.Console
{
    class Program
    {
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
                System.Console.ReadLine();             

                xbc.Disconnect();
            }

            return 0;
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

            if (DateTime.Now.Subtract(lastUpdate).TotalMilliseconds < 1000)
                return;
            lastUpdate = DateTime.Now;

            StringBuilder sb = new StringBuilder();
            XDreamClient xbc = (XDreamClient)sender;

            if (deltaR!=0)
            {
                xbc.Resistance += deltaR;
                deltaR = 0;
            }

            sb.AppendLine($"Port              : {comPort}");
            sb.AppendLine($"Steering          : {e.Steering}  / {XDreamClient.MaxSteeringPosition}");
            sb.AppendLine($"Left Brake        : {e.LeftBrake} / {XDreamClient.MaxBrakePosition}");
            sb.AppendLine($"Right Brake       : {e.RightBrake} / {XDreamClient.MaxBrakePosition}");
            sb.AppendLine($"Crank Position    : {e.CrankPosition} / {XDreamClient.CrankPositions}");
            sb.AppendLine($"Flywheel Rev Time : {e.FlywheelRevolutionTime}");
            sb.AppendLine($"Heart Rate        : {e.HeartRate}");
            sb.AppendLine($"Buttons           : {e.Buttons}");
            sb.AppendLine($"Resistance        : {(sender as XDreamClient)?.Resistance} / {XDreamClient.MaximumResistance}");

            System.Console.Clear();
            System.Console.WriteLine(sb.ToString());

        }
    }
}
