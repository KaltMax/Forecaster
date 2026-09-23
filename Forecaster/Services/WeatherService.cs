using Forecaster.Models.Api;
using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forecaster.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IOpenWeatherMapUrlBuilder _urlBuilder;
        private readonly IGeoInfoService _geoInfoService;

        public WeatherService(HttpClient httpClient, IOpenWeatherMapUrlBuilder urlBuilder,
            IGeoInfoService geoInfoService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _urlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
            _geoInfoService = geoInfoService ?? throw new ArgumentNullException(nameof(geoInfoService));
        }

        public async Task<WeatherInfo> GetWeatherAsync(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                throw new ArgumentException(@"City name cannot be null or empty.", nameof(cityName));
            }

            // Returns null only when the city was not found. API failures throw a WeatherApiException
            var geoInfo = await _geoInfoService.GetGeoInfoAsync(cityName);
            if (geoInfo == null)
            {
                return null;
            }

            var weatherApiUrl = _urlBuilder.BuildWeatherApiUrl(geoInfo.Latitude, geoInfo.Longitude);
            var weatherResponse = await _httpClient.GetFromOpenWeatherMapAsync<WeatherResponse>(weatherApiUrl);

            var weatherInfo = MapToWeatherInfo(weatherResponse);
            weatherInfo.CityName = $"{geoInfo.Name}, {geoInfo.Country}";
            return weatherInfo;
        }

        private WeatherInfo MapToWeatherInfo(WeatherResponse weatherResponse)
        {
            if (weatherResponse.Main == null ||
                weatherResponse.Weather == null ||
                weatherResponse.Weather.Count == 0 ||
                weatherResponse.Wind == null ||
                weatherResponse.Sys == null ||
                weatherResponse.Coord == null)
            {
                throw new WeatherApiException(WeatherApiErrorKind.InvalidResponse, "incomplete weather data");
            }

            return new WeatherInfo
            {
                CityName = weatherResponse.Name,
                MeasurementTime = weatherResponse.Dt,
                Latitude = weatherResponse.Coord.Lat,
                Longitude = weatherResponse.Coord.Lon,
                Temperature = weatherResponse.Main.Temp,
                Humidity = weatherResponse.Main.Humidity,
                Pressure = weatherResponse.Main.Pressure,
                WeatherCondition = weatherResponse.Weather[0].Description,
                WindSpeed = weatherResponse.Wind.Speed,
                Icon = weatherResponse.Weather[0].Icon,
                Sunrise = weatherResponse.Sys.Sunrise,
                Sunset = weatherResponse.Sys.Sunset,
                TimezoneOffsetSeconds = weatherResponse.Timezone
            };
        }
    }
}