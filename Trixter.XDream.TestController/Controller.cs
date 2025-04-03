using System;
using Trixter.XDream.API;
using Trixter.XDream.API.Communications;
using Trixter.XDream.API.Generators;
using Trixter.XDream.API.Meters;

namespace Trixter.XDream.TestController
{
    class Controller
    {
        private XDreamSerialPortServer server;
        private AutoCranker autoCranker;
        private System.Timers.Timer crankTimer;
        private DateTimeOffset lastCrankUpdate;
        private string comPort;

        public bool IsConnected { get; private set; }

        public string COMPort
        {
            get => this.comPort;
            set
            {
                if (this.IsConnected)
                    throw new InvalidOperationException("Cannot set COM port while connected.");
                this.comPort = value;

            } 
        }

        public XDreamStateBuilder State { get;  }

        public int Resistance { get; private set; } = 0;

        public double ResistanceRequestsPerSecond => this.server.ResistancePacketsPerSecond;

        public event CrankPositionChangedDelegate<Controller> CrankPositionChanged;

        public int CrankRPM
        { 
            get => this.autoCranker.RPM;
            set
            {
                this.autoCranker.RPM = value;
                this.crankTimer.Stop();
                this.crankTimer.Interval = this.autoCranker.MillisecondsPerPosition;
                
                if (value > 0)
                    this.crankTimer.Start();
                else                
                    this.CrankTimer_Elapsed(this.crankTimer, null);
            }
        }

        public event XDreamResistanceChangedDelegate<Controller> ResistanceChanged;
        

        // https://github.com/rdelhommer/com0com-c_sharp-wrapper/blob/master/examples/Com0Com.CSharp.Examples/Program.cs


        public Controller()
        {
            this.State = new XDreamStateBuilder();
            this.State.Flywheel = 65534;
            this.server = new XDreamSerialPortServer();
            this.server.ResistanceChanged += Server_ResistanceChanged;

            this.autoCranker = new AutoCranker();
            this.autoCranker.CrankPositionChanged += AutoCranker_CrankPositionChanged;

            this.crankTimer = new System.Timers.Timer();
            this.crankTimer.Elapsed += CrankTimer_Elapsed;
        }

        private void CrankTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            if (now > this.lastCrankUpdate)
            {
                this.lastCrankUpdate = now;
                this.autoCranker.Update(now);
            }
        }

        private void AutoCranker_CrankPositionChanged(ICadenceProvider sender, int delta)
        {
            this.State.Crank = MappedCrankMeter.DefaultMappingRpmToRaw(sender.RPM);
            this.State.CrankPosition = sender.CrankPosition;
            this.Send();

            this.CrankPositionChanged?.Invoke(this, delta);
        }
           

        private void Server_ResistanceChanged(XDreamServer sender)
        {
            this.Resistance = this.server.Resistance;
            this.ResistanceChanged?.Invoke(this);
        }

        public void Connect()
        {
            //    Com0Com.CSharp.Com0ComSetupCFacade setupCFacade = new Com0Com.CSharp.Com0ComSetupCFacade();
            //var pairs = this.setupCFacade.GetCrossoverPortPairs();

            //    foreach(var pair in pairs)
            //    {
            //        if (pair.PortNameA == "COM13" && pair.PortNameB == "COM14")
            //        {
            //            this.portPair = pair;
            //            break;
            //        }
            //    }

            //this.portPair = this.setupCFacade.CreatePortPair("COM13", "COM14");

            if (this.IsConnected)
                throw new InvalidOperationException("Already connected.");

            if (string.IsNullOrWhiteSpace(this.COMPort))
                throw new InvalidOperationException("COM Port not set");


            this.server.Connect(this.COMPort);
            this.IsConnected = true;
        }

        public void Disconnect()
        {
            if (!this.IsConnected)
                throw new InvalidOperationException("Not connected.");

            this.server.Disconnect();
            this.IsConnected = false;
        }

        public void Send() 
        {
            this.server.State = this.State.ToReadOnly();
        }

    }
}
