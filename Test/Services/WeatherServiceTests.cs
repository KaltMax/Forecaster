using Forecaster.Models.Api;
using Forecaster.Models.Domain;
using Forecaster.Models.Shared;
using Forecaster.Services;
using Forecaster.Services.Interfaces;
using Moq;
using RichardSzalay.MockHttp;
using System.Net;
using System.Text.Json;

namespace Test.Services
{
    public class WeatherServiceTests
    {
        private readonly Mock<IOpenWeatherMapUrlBuilder> _urlBuilderMock;
        private readonly Mock<IGeoInfoService> _geoInfoServiceMock;
        private readonly MockHttpMessageHandler _mockHttpHttpMessageHandler;
        private readonly WeatherService _weatherService;

        public WeatherServiceTests()
        {
            _urlBuilderMock = new Mock<IOpenWeatherMapUrlBuilder>();
            _geoInfoServiceMock = new Mock<IGeoInfoService>();
            _mockHttpHttpMessageHandler = new MockHttpMessageHandler();
            var httpClient = new HttpClient(_mockHttpHttpMessageHandler);
            _weatherService = new WeatherService(httpClient, _urlBuilderMock.Object, _geoInfoServiceMock.Object);
        }

        [Fact]
        public async Task GetWeatherAsync_ValidCityName_ReturnsWeatherInfo()
        {
            // Arrange
            var cityName = "New York";
            var geoInfo = new GeoInfo { Name = "New York", Latitude = 40.7128, Longitude = -74.0060, Country = "US" };

            _geoInfoServiceMock
                .Setup(service => service.GetGeoInfoAsync(cityName))
                .ReturnsAsync(geoInfo);

            _urlBuilderMock
                .Setup(builder => builder.BuildWeatherApiUrl(geoInfo.Latitude, geoInfo.Longitude))
                .Returns("http://mockurl.com");

            _mockHttpHttpMessageHandler
                .When("http://mockurl.com")
                .Respond("application/json", JsonSerializer.Serialize(new WeatherResponse
                {
                    Name = "New York",
                    Main = new Main { Temp = 25.0 },
                    Coord = new Coord { Lat = 40.7128, Lon = -74.0060 },
                    Weather = new List<Weather> { new Weather { Description = "Clear", Icon = "01d" } },
                    Wind = new Wind { Speed = 5.0 },
                    Sys = new Sys { Sunrise = 1627890000, Sunset = 1627933200 }
                }));

            // Act
            var result = await _weatherService.GetWeatherAsync(cityName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New York, US", result.CityName);
            Assert.Equal(25.0, result.Temperature);
        }

        [Fact]
        public async Task GetWeatherAsync_InvalidCityName_ThrowsArgumentException()
        {
            // Arrange
            var cityName = "";

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _weatherService.GetWeatherAsync(cityName));
        }

        [Fact]
        public async Task GetWeatherAsync_GeoInfoNotFound_ReturnsNull()
        {
            // Arrange
            var cityName = "Unknown City";

            _geoInfoServiceMock
                .Setup(service => service.GetGeoInfoAsync(cityName))
                .ReturnsAsync((GeoInfo)null!);

            // Act
            var result = await _weatherService.GetWeatherAsync(cityName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetWeatherAsync_HttpRequestException_ThrowsInvalidOperationException()
        {
            // Arrange
            var cityName = "New York";
            var geoInfo = new GeoInfo { Name = "New York", Latitude = 40.7128, Longitude = -74.0060, Country = "US" };

            _geoInfoServiceMock
                .Setup(service => service.GetGeoInfoAsync(cityName))
                .ReturnsAsync(geoInfo);

            _urlBuilderMock
                .Setup(builder => builder.BuildWeatherApiUrl(geoInfo.Latitude, geoInfo.Longitude))
                .Returns("http://mockurl.com");

            _mockHttpHttpMessageHandler
                .When("http://mockurl.com")
                .Respond(HttpStatusCode.InternalServerError);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _weatherService.GetWeatherAsync(cityName));
        }

        [Fact]
        public async Task GetWeatherAsync_InvalidJsonResponse_ThrowsInvalidOperationException()
        {
            // Arrange
            var cityName = "New York";
            var geoInfo = new GeoInfo { Name = "New York", Latitude = 40.7128, Longitude = -74.0060, Country = "US" };

            _geoInfoServiceMock
                .Setup(service => service.GetGeoInfoAsync(cityName))
                .ReturnsAsync(geoInfo);

            _urlBuilderMock
                .Setup(builder => builder.BuildWeatherApiUrl(geoInfo.Latitude, geoInfo.Longitude))
                .Returns("http://mockurl.com");

            _mockHttpHttpMessageHandler
                .When("http://mockurl.com")
                .Respond("application/json", "{");

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _weatherService.GetWeatherAsync(cityName));
        }
    }
}