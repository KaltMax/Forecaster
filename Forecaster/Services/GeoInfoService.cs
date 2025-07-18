using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Forecaster.Models;
using Forecaster.Services.Interfaces;

namespace Forecaster.Services
{
    public class GeoInfoService : IGeoInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly IOpenWeatherMapUrlBuilder _urlBuilder;

        public GeoInfoService(HttpClient httpClient, IOpenWeatherMapUrlBuilder urlBuilder)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _urlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<GeoInfo> GetGeoInfoAsync(string cityName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cityName))
                    throw new ArgumentException(@"City name cannot be null or empty.", nameof(cityName));

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
    }
}