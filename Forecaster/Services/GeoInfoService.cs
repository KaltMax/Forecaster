using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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
            if (string.IsNullOrWhiteSpace(cityName))
            {
                throw new ArgumentException(@"City name cannot be null or empty.", nameof(cityName));
            }

            var geoApiUrl = _urlBuilder.BuildGeoApiUrl(cityName);
            var geoResponse = await _httpClient.GetFromOpenWeatherMapAsync<List<GeoInfo>>(geoApiUrl);

            // An empty list means the city was not found, which is not an error
            return geoResponse.Count > 0 ? geoResponse[0] : null;
        }
    }
}