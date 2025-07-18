namespace Forecaster.Services.Interfaces
{
    public interface IOpenWeatherMapUrlBuilder
    {
        string BuildGeoApiUrl(string cityName);
        string BuildWeatherApiUrl(double latitude, double longitude);
        string BuildForecastApiUrl(double latitude, double longitude);
    }
}