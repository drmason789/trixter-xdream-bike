using System;
using Trixter.XDream.API;

namespace Trixter.XDream.Diagnostics
{
    public class DataAccess
    {
        private object sync = new object();
        private XDreamMachine xDreamMachine;

        public event XDreamStateUpdatedDelegate<DataAccess> StateUpdated;

        public XDreamMachine XDreamMachine
        {
            get { lock(this.sync) return xDreamMachine; }
            set
            {
                lock (this.sync)
                {
                    if (object.ReferenceEquals(this.xDreamMachine, value))
                        return;

                    // unhook the old event handler
                    if (this.xDreamMachine != null)
                        this.xDreamMachine.StateUpdated -= this.Update;

                    this.xDreamMachine = value;

                    if(value!=null)
                        this.xDreamMachine.StateUpdated += this.Update;
                }
            }
        }

        public XDreamState LastMessage { get; private set; }

        private void Update(object sender, XDreamState message)
        {
            lock (this.sync)
            {
                this.LastMessage = message;
            }

            this.StateUpdated?.Invoke(this, message);
        }
    }
}