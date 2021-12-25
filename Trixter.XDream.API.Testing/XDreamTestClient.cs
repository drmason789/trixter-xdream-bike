namespace Trixter.XDream.API
{
    public class XDreamTestClient : XDreamClient
    {
        public int Resistance { get; set; }

        public event XDreamStateUpdatedDelegate<XDreamClient> StateUpdated;

        public void UpdateState(XDreamState state)
        {
            this.StateUpdated?.Invoke(this, state);
        }

    }
}
