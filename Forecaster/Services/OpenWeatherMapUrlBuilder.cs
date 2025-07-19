using System;
using Microsoft.Extensions.Configuration;
using Forecaster.Services.Interfaces;

namespace Forecaster.Services
{
    public class OpenWeatherMapUrlBuilder : IOpenWeatherMapUrlBuilder
    {
        private readonly string _apiKey;

        // Constants
        private const string BaseApiUrl = "https://api.openweathermap.org";
        private const string GeoApiPath = "/geo/1.0/direct";
        private const string WeatherApiPath = "/data/2.5/weather";
        private const string ForecastApiPath = "/data/2.5/forecast";
        private const string Units = "metric";
        private const int GeoLocationLimit = 1;

        public OpenWeatherMapUrlBuilder(IConfiguration configuration)
        {
            _apiKey = configuration["ApiSettings:OpenWeatherMapApiKey"];

            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new InvalidOperationException("API key for OpenWeatherMap is missing or not set. Please check your appsettings.json file.");
            }
        }

        public string BuildGeoApiUrl(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                throw new ArgumentException(@"City name cannot be null or empty.", nameof(cityName));
            }

            return $"{BaseApiUrl}{GeoApiPath}?q={Uri.EscapeDataString(cityName)}&limit={GeoLocationLimit}&appid={_apiKey}";
        }

        public string BuildWeatherApiUrl(double latitude, double longitude)
        {
            return $"{BaseApiUrl}{WeatherApiPath}?lat={latitude:F6}&lon={longitude:F6}&units={Units}&appid={_apiKey}";
        }

        public string BuildForecastApiUrl(double latitude, double longitude)
        {
            return $"{BaseApiUrl}{ForecastApiPath}?lat={latitude:F6}&lon={longitude:F6}&units={Units}&appid={_apiKey}";
        }
    }
}