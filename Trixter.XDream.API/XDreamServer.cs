namespace Trixter.XDream.API
{
#pragma warning disable IDE1006 // Naming Styles
    public interface XDreamServer
#pragma warning restore IDE1006 // Naming Styles
    {
        event XDreamResistanceChangedDelegate<XDreamServer> ResistanceChanged;

        int Resistance { get; }

        XDreamState State { get; set; }
    }
}
