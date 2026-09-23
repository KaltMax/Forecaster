using Forecaster.Models.Domain;
using Forecaster.Services;
using Forecaster.Services.Interfaces;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.Net;
using System.Text.Json;

namespace Test.Services
{
    public class GeoInfoServiceTests
    {
        private readonly IOpenWeatherMapUrlBuilder _urlBuilder;
        private readonly MockHttpMessageHandler _mockHttpHttpMessageHandler;
        private readonly GeoInfoService _geoInfoService;

        public GeoInfoServiceTests()
        {
            _urlBuilder = Substitute.For<IOpenWeatherMapUrlBuilder>();
            _mockHttpHttpMessageHandler = new MockHttpMessageHandler();

            var httpClient = new HttpClient(_mockHttpHttpMessageHandler);
            _geoInfoService = new GeoInfoService(httpClient, _urlBuilder);
        }

        [Fact]
        public async Task GetGeoInfoAsync_WithValidCity_ReturnsGeoInfo()
        {
            // Arrange
            var cityName = "London";
            var fakeApiUrl = "http://fake-api.com/geo/london";
            var expectedGeoInfo = new GeoInfo { Name = "London", Latitude = 51.5074, Longitude = -0.1278, Country = "GB" };

            var apiResponse = new List<GeoInfo> { expectedGeoInfo };
            var jsonResponse = JsonSerializer.Serialize(apiResponse);

            _urlBuilder.BuildGeoApiUrl(cityName).Returns(fakeApiUrl);

            // Use MockHttpMessageHandler to mock the HTTP response
            _mockHttpHttpMessageHandler.When(fakeApiUrl).Respond("application/json", jsonResponse);

            // Act
            var result = await _geoInfoService.GetGeoInfoAsync(cityName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedGeoInfo.Name, result.Name);
            Assert.Equal(expectedGeoInfo.Latitude, result.Latitude);
            Assert.Equal(expectedGeoInfo.Longitude, result.Longitude);
            Assert.Equal(expectedGeoInfo.Country, result.Country);
        }

        [Fact]
        public async Task GetGeoInfoAsync_WhenApiReturnsEmptyList_ReturnsNull()
        {
            // Arrange
            var cityName = "UnknownCity";
            var fakeApiUrl = "http://fake-api.com/geo/unknown";

            _urlBuilder.BuildGeoApiUrl(cityName).Returns(fakeApiUrl);

            // Mock an empty JSON array response
            _mockHttpHttpMessageHandler.When(fakeApiUrl).Respond("application/json", "[]");

            // Act
            var result = await _geoInfoService.GetGeoInfoAsync(cityName);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public async Task GetGeoInfoAsync_WithNullOrEmptyCity_ThrowsArgumentException(string invalidCityName)
        {
            // Arrange, Act, and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _geoInfoService.GetGeoInfoAsync(invalidCityName));
        }

        [Fact]
        public async Task GetGeoInfoAsync_WhenApiKeyIsRejected_ThrowsInvalidApiKeyError()
        {
            // Arrange
            var cityName = "London";
            var fakeApiUrl = "http://fake-api.com/geo/london";

            _urlBuilder.BuildGeoApiUrl(cityName).Returns(fakeApiUrl);
            _mockHttpHttpMessageHandler.When(fakeApiUrl).Respond(HttpStatusCode.Unauthorized);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() => _geoInfoService.GetGeoInfoAsync(cityName));
            Assert.Equal(WeatherApiErrorKind.InvalidApiKey, exception.Kind);
        }

        [Fact]
        public async Task GetGeoInfoAsync_WhenConnectionFails_ThrowsNetworkError()
        {
            // Arrange
            var cityName = "London";
            var fakeApiUrl = "http://fake-api.com/geo/london";

            _urlBuilder.BuildGeoApiUrl(cityName).Returns(fakeApiUrl);
            var connectionError = new HttpRequestException("No such host is known.");
            _mockHttpHttpMessageHandler.When(fakeApiUrl).Throw(connectionError);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() => _geoInfoService.GetGeoInfoAsync(cityName));
            Assert.Equal(WeatherApiErrorKind.NetworkError, exception.Kind);
            Assert.Same(connectionError, exception.InnerException);
        }
    }
}