namespace Trixter.XDream.API.Filters
{
    internal interface IMeanCalculator
    {
        double Mean { get; }
        double Sum { get; }

        void Reset();
    }
}
