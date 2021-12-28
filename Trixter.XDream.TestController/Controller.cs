using System;
using Trixter.XDream.API;
using Trixter.XDream.API.Generators;

namespace Trixter.XDream.TestController
{
    class Controller
    {
        private XDreamSerialPortServer server;
        private AutoCranker autoCranker;
        private System.Timers.Timer crankTimer;

        public XDreamStateBuilder State { get;  }

        public int Resistance { get; private set; } = 0;

        public event CrankPositionChangedDelegate<Controller> CrankPositionChanged;

        public int CrankRPM
        { 
            get => this.autoCranker.RPM;
            set
            {
                this.autoCranker.RPM = value;
                this.crankTimer.Stop();
                this.crankTimer.Interval = this.autoCranker.MillisecondsPerPosition;
                this.crankTimer.Enabled = value > 0;
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
            this.autoCranker.Update(DateTimeOffset.Now);
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
            this.server.Connect("COM15");
        }

        public void Disconnect()
        {
            
        }

        public void Send() 
        {
            this.server.State = this.State.ToReadOnly();
        }

    }
}
