namespace Trixter.XDream.API
{
#pragma warning disable IDE1006 // Naming Styles
    public interface XDreamClient
#pragma warning restore IDE1006 // Naming Styles
    {
        event XDreamStateUpdatedDelegate<XDreamClient> StateUpdated;

        int Resistance { get; set; }
    }
}
