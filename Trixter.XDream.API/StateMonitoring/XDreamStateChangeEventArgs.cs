using System.Diagnostics;

namespace Trixter.XDream.API.StateMonitoring
{
    [DebuggerDisplay("Changes: {Changes}")]
    public class XDreamStateChangeEventArgs
    {
        public XDreamStateChanges Changes { get;  }
        public XDreamControllerButtons ButtonsUp => this.PreviousState.Buttons & ~this.State.Buttons;
        public XDreamControllerButtons ButtonsDown => this.State.Buttons & ~this.PreviousState.Buttons;
        public XDreamState State { get; }
        public XDreamState PreviousState { get; }

        public XDreamStateChangeEventArgs(XDreamStateChanges changes, XDreamState state, XDreamState previous)
        {
            this.Changes = changes;
            this.State = state;
            this.PreviousState = previous;
        }
    }
}
