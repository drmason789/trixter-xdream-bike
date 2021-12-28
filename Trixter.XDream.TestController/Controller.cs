using Trixter.XDream.API;

namespace Trixter.XDream.Controller
{
    class Controller
    {
        private XDreamSerialPortServer server;

        public XDreamStateBuilder State { get;  }

        public int Resistance { get; private set; } = 0;

        public Pedaller Pedaller { get; private set; }

        public event XDreamResistanceChangedDelegate<Controller> ResistanceChanged;
        

        // https://github.com/rdelhommer/com0com-c_sharp-wrapper/blob/master/examples/Com0Com.CSharp.Examples/Program.cs


        public Controller()
        {
            this.State = new XDreamStateBuilder();
            this.State.Flywheel = 65534;
            this.server = new XDreamSerialPortServer();
            this.server.ResistanceChanged += Server_ResistanceChanged;
            this.Pedaller = new Pedaller();
            this.Pedaller.CrankPositionChanged += Pedaller_CrankPositionChanged;
            
        }

        private void Pedaller_CrankPositionChanged(Pedaller sender, int newPosition)
        {
            this.State.Crank = sender.CrankTime;
            this.State.CrankPosition = sender.CrankPosition;
            this.Send();
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
