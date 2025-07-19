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
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IOpenWeatherMapUrlBuilder _urlBuilder;

        private const int MinimumForecastCount = 4;

        public ForecastService(HttpClient httpClient, IOpenWeatherMapUrlBuilder urlBuilder)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _urlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double latitude, double longitude)
        {
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
            if (forecastResponse?.List == null || forecastResponse.List.Count < MinimumForecastCount)
            {
                return null;
            }

            var forecastInfos = (from forecast in forecastResponse.List.Skip(1)
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

            // Skip the first entry (current time) and map the rest
            return forecastInfos.Count > 0 ? forecastInfos : null;
        }
    }
}