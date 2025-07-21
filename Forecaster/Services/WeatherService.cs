using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Forecaster.Models.Api;
using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;

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
            try
            {
                if (string.IsNullOrWhiteSpace(cityName))
                {
                    throw new ArgumentException(@"City name cannot be null or empty.", nameof(cityName));
                }

                var geoInfo = await _geoInfoService.GetGeoInfoAsync(cityName);
                if (geoInfo == null)
                {
                    return null;
                }

                var weatherInfo = await GetWeatherByCoordinatesAsync(geoInfo.Latitude, geoInfo.Longitude);
                if (weatherInfo != null)
                {
                    weatherInfo.CityName = $"{geoInfo.Name}, {geoInfo.Country}";
                }

                return weatherInfo;
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException(
                    $"Failed to retrieve weather data for {cityName}. Please check your internet connection.", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Failed to parse weather data for {cityName}.", ex);
            }
        }

        private async Task<WeatherInfo> GetWeatherByCoordinatesAsync(double lat, double lon)
        {
            try
            {
                var weatherApiUrl = _urlBuilder.BuildWeatherApiUrl(lat, lon);

                using var response = await _httpClient.GetAsync(weatherApiUrl);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(responseContent);

                return MapToWeatherInfo(weatherResponse);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get weather data for coordinates ({lat:F6}, {lon:F6}).",
                    ex);
            }
        }

        private WeatherInfo MapToWeatherInfo(WeatherResponse weatherResponse)
        {
            if (weatherResponse?.Main == null ||
                weatherResponse.Weather == null ||
                weatherResponse.Weather.Count == 0 ||
                weatherResponse.Wind == null ||
                weatherResponse.Sys == null ||
                weatherResponse.Coord == null)
            {
                return null;
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
                Sunset = weatherResponse.Sys.Sunset
            };
        }
    }
}