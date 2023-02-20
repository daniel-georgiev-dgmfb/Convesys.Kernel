namespace Twilight.Kernel.Spatial
{
    public interface ILocationService
    {
        Task<Tuple<double, double>> GetLocation(Tuple<long, long, double> readings1, Tuple<long, long, double> readings2, Tuple<long, long, double> readings3);

        Task<float> CalculateDistance(Tuple<float, float> coordinatesFrom, Tuple<float, float> coordinatesTo);
    }
}