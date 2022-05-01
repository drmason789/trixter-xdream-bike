namespace Trixter.XDream.API.Filters
{
    /// <summary>
    /// Basic functionality for getting the mean and sum from a mean (average) calculating object.
    /// </summary>
    internal interface IMeanCalculator
    {
        double Mean { get; }
        double Sum { get; }

        void Add(double value, double weight);
        void Remove(double value, double weight);
        void Update(double value, double oldWeight, double newWeight);

        void Reset();
    }
}
