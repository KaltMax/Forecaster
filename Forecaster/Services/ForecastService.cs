using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Forecaster.Models.Api;
using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;

namespace Forecaster.Services
{
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IOpenWeatherMapUrlBuilder _urlBuilder;

        public ForecastService(HttpClient httpClient, IOpenWeatherMapUrlBuilder urlBuilder)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _urlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double latitude, double longitude)
        {
            if (latitude is < -90 or > 90 || longitude is < -180 or > 180)
            {
                throw new ArgumentOutOfRangeException(
                    $"Invalid coordinates: Latitude must be between -90 and 90 degrees, and Longitude must be between -180 and 180 degrees. Provided values: Latitude = {latitude:F6}, Longitude = {longitude:F6}."
                );
            }

            try
            {
                var forecastApiUrl = _urlBuilder.BuildForecastApiUrl(latitude, longitude);

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
                throw new InvalidOperationException($"Failed to get forecast data for coordinates ({latitude:F6}, {longitude:F6}).", ex);
            }
        }

        private List<ForecastInfo> MapToForecastInfoList(ForecastResponse forecastResponse)
        {
            if (forecastResponse?.List == null)
            {
                return null;
            }

            var forecastInfos = (from forecast in forecastResponse.List
            where forecast is { Main: not null, Weather.Count: > 0, Wind: not null }
            select new ForecastInfo
            {
                Temperature = forecast.Main.Temp,
                Humidity = forecast.Main.Humidity,
                WeatherCondition = forecast.Weather[0].Description,
                WindSpeed = forecast.Wind.Speed,
                Icon = forecast.Weather[0].Icon,
                DateTime = forecast.Dt
            }).ToList();

            return forecastInfos.Count > 0 ? forecastInfos : null;
        }
    }
}