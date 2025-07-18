using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Forecaster.Models;
using Forecaster.Services.Interfaces;

namespace Forecaster.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IOpenWeatherMapUrlBuilder _urlBuilder;
        private readonly string _apiKey;

        private const int MinimumForecastCount = 4;

        public WeatherService(HttpClient httpClient, IOpenWeatherMapUrlBuilder urlBuilder)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _urlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<WeatherInfo> GetWeatherAsync(string cityName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cityName))
                {
                    throw new ArgumentException("City name cannot be null or empty.", nameof(cityName));
                }
                
                var geoInfo = await GetGeoInfoAsync(cityName);
                if (geoInfo == null)
                {
                    return null;
                }

                var weatherInfo = await GetWeatherByCoordinatesAsync(geoInfo.Latitude, geoInfo.Longitude);
                if (weatherInfo != null)
                {
                    weatherInfo.CityName = geoInfo.Name;
                }
                return weatherInfo;
            }
            catch (HttpRequestException ex)
            {
                throw new InvalidOperationException($"Failed to retrieve weather data for {cityName}. Please check your internet connection.", ex);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Failed to parse weather data for {cityName}.", ex);
            }
        }

        private async Task<GeoInfo> GetGeoInfoAsync(string cityName)
        {
            try
            {
                string geoApiUrl = _urlBuilder.BuildGeoApiUrl(cityName);

                using var response = await _httpClient.GetAsync(geoApiUrl);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var geoResponse = JsonSerializer.Deserialize<List<GeoInfo>>(responseContent);

                return geoResponse?.Count > 0 ? geoResponse[0] : null;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get geographic information for {cityName}.", ex);
            }
        }

        private async Task<WeatherInfo> GetWeatherByCoordinatesAsync(double lat, double lon)
        {
            try
            {
                string weatherApiUrl = _urlBuilder.BuildWeatherApiUrl(lat, lon);

                using var response = await _httpClient.GetAsync(weatherApiUrl);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(responseContent);

                return MapToWeatherInfo(weatherResponse, lat, lon);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get weather data for coordinates ({lat:F6}, {lon:F6}).", ex);
            }
        }

        public async Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double lat, double lon)
        {
            try
            {
                string forecastApiUrl = _urlBuilder.BuildForecastApiUrl(lat, lon);

                using var response = await _httpClient.GetAsync(forecastApiUrl);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var forecastResponse = JsonSerializer.Deserialize<ForecastResponse>(responseContent);

                return MapToForecastInfoList(forecastResponse);
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get forecast data for coordinates ({lat:F6}, {lon:F6}).", ex);
            }
        }

        // Mapping Helper Methods
        private WeatherInfo MapToWeatherInfo(WeatherResponse weatherResponse, double lat, double lon)
        {
            if (weatherResponse?.Main == null ||
                weatherResponse.Weather == null ||
                weatherResponse.Weather.Count == 0 ||
                weatherResponse.Wind == null ||
                weatherResponse.Sys == null)
            {
                return null;
            }

            return new WeatherInfo
            {
                Latitude = lat,
                Longitude = lon,
                Temperature = weatherResponse.Main.Temp,
                Humidity = weatherResponse.Main.Humidity,
                WeatherCondition = weatherResponse.Weather[0].Description,
                WindSpeed = weatherResponse.Wind.Speed,
                CityName = weatherResponse.Name,
                Icon = weatherResponse.Weather[0].Icon,
                Sunrise = weatherResponse.Sys.Sunrise,
                Sunset = weatherResponse.Sys.Sunset
            };
        }

        private List<ForecastInfo> MapToForecastInfoList(ForecastResponse forecastResponse)
        {
            if (forecastResponse?.List == null || forecastResponse.List.Count < MinimumForecastCount)
            {
                return null;
            }

            var forecastInfos = new List<ForecastInfo>();

            // Skip the first entry (current time) and map the rest
            foreach (var forecast in forecastResponse.List.Skip(1))
            {
                if (forecast?.Main != null &&
                    forecast.Weather != null &&
                    forecast.Weather.Count > 0 &&
                    forecast.Wind != null)
                {
                    forecastInfos.Add(new ForecastInfo
                    {
                        Temperature = forecast.Main.Temp,
                        Humidity = forecast.Main.Humidity,
                        WeatherCondition = forecast.Weather[0].Description,
                        WindSpeed = forecast.Wind.Speed,
                        Icon = forecast.Weather[0].Icon,
                        DateTime = forecast.Dt
                    });
                }
            }

            return forecastInfos.Count > 0 ? forecastInfos : null;
        }
    }
}