using Forecaster.Models.Domain;
using Forecaster.Services;
using Forecaster.Services.Interfaces;
using Moq;
using RichardSzalay.MockHttp;
using System.Net;
using System.Text.Json;

namespace Test.Services
{
    public class GeoInfoServiceTests
    {
        private readonly Mock<IOpenWeatherMapUrlBuilder> _urlBuilderMock;
        private readonly MockHttpMessageHandler _mockHttpHttpMessageHandler;
        private readonly GeoInfoService _geoInfoService;

        public GeoInfoServiceTests()
        {
            _urlBuilderMock = new Mock<IOpenWeatherMapUrlBuilder>();
            _mockHttpHttpMessageHandler = new MockHttpMessageHandler();

            var httpClient = new HttpClient(_mockHttpHttpMessageHandler);
            _geoInfoService = new GeoInfoService(httpClient, _urlBuilderMock.Object);
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

            _urlBuilderMock.Setup(x => x.BuildGeoApiUrl(cityName)).Returns(fakeApiUrl);

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

            _urlBuilderMock.Setup(x => x.BuildGeoApiUrl(cityName)).Returns(fakeApiUrl);

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
        public async Task GetGeoInfoAsync_WhenApiCallFails_ThrowsHttpRequestException()
        {
            // Arrange
            var cityName = "London";
            var fakeApiUrl = "http://fake-api.com/geo/london";

            _urlBuilderMock.Setup(x => x.BuildGeoApiUrl(cityName)).Returns(fakeApiUrl);

            // Mock a 404 Not Found response
            _mockHttpHttpMessageHandler.When(fakeApiUrl).Respond(HttpStatusCode.NotFound);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => _geoInfoService.GetGeoInfoAsync(cityName));
        }

        [Fact]
        public async Task GetGeoInfoAsync_WhenUnexpectedExceptionOccurs_ThrowsInvalidOperationException()
        {
            // Arrange
            var cityName = "London";
            var fakeApiUrl = "http://fake-api.com/geo/london";

            _urlBuilderMock.Setup(x => x.BuildGeoApiUrl(cityName)).Returns(fakeApiUrl);

            // Simulate an unexpected exception by throwing from the handler
            _mockHttpHttpMessageHandler.When(fakeApiUrl).Throw(new Exception("Unexpected error"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _geoInfoService.GetGeoInfoAsync(cityName));
            Assert.Equal($"Failed to get geographic information for {cityName}.", exception.Message);
            Assert.IsType<Exception>(exception.InnerException);
            Assert.Equal("Unexpected error", exception.InnerException?.Message);
        }
    }
}