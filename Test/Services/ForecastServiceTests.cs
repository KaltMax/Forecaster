using Forecaster.Models.Api;
using Forecaster.Models.Shared;
using Forecaster.Services;
using Forecaster.Services.Interfaces;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.Net;
using System.Text.Json;

namespace Test.Services
{
    public class ForecastServiceTests
    {
        private readonly IOpenWeatherMapUrlBuilder _urlBuilder;
        private readonly MockHttpMessageHandler _mockHttpMessageHandler;
        private readonly ForecastService _forecastService;

        public ForecastServiceTests()
        {
            _urlBuilder = Substitute.For<IOpenWeatherMapUrlBuilder>();
            _mockHttpMessageHandler = new MockHttpMessageHandler();
            var httpClient = new HttpClient(_mockHttpMessageHandler);
            _forecastService = new ForecastService(httpClient, _urlBuilder);
        }

        [Fact]
        public async Task GetForecastByCoordinatesAsync_ValidCoordinates_ReturnsForecastInfoList()
        {
            // Arrange
            var latitude = 40.7128;
            var longitude = -74.0060;
            var apiUrl = "https://api.openweathermap.org/data/2.5/forecast";
            var mockResponse = new ForecastResponse
            {
                List = new List<Forecast>
                {
                    new Forecast
                    {
                        Dt = 1625247600,
                        Main = new Main { Temp = 298.15, Humidity = 60 },
                        Weather = new List<Weather> { new Weather { Description = "clear sky", Icon = "01d" } },
                        Wind = new Wind { Speed = 5.1 }
                    }
                }
            };

            _urlBuilder.BuildForecastApiUrl(latitude, longitude).Returns(apiUrl);

            _mockHttpMessageHandler
                .When(apiUrl)
                .Respond("application/json", JsonSerializer.Serialize(mockResponse));

            // Act
            var result = await _forecastService.GetForecastByCoordinatesAsync(latitude, longitude);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(298.15, result[0].Temperature);
            Assert.Equal(60, result[0].Humidity);
            Assert.Equal("clear sky", result[0].WeatherCondition);
            Assert.Equal(5.1, result[0].WindSpeed);
            Assert.Equal("01d", result[0].Icon);
        }

        [Fact]
        public async Task GetForecastByCoordinatesAsync_InvalidCoordinates_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var latitude = 100.0; // Invalid latitude
            var longitude = 200.0; // Invalid longitude

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                _forecastService.GetForecastByCoordinatesAsync(latitude, longitude));
        }

        [Fact]
        public async Task GetForecastByCoordinatesAsync_ServerError_ThrowsServiceError()
        {
            // Arrange
            var latitude = 40.7128;
            var longitude = -74.0060;
            var apiUrl = "https://api.openweathermap.org/data/2.5/forecast";

            _urlBuilder.BuildForecastApiUrl(latitude, longitude).Returns(apiUrl);

            _mockHttpMessageHandler
                .When(apiUrl)
                .Respond(HttpStatusCode.InternalServerError);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() =>
                _forecastService.GetForecastByCoordinatesAsync(latitude, longitude));
            Assert.Equal(WeatherApiErrorKind.ServiceError, exception.Kind);
        }

        [Fact]
        public async Task GetForecastByCoordinatesAsync_ResponseWithoutList_ThrowsInvalidResponseError()
        {
            // Arrange
            var latitude = 40.7128;
            var longitude = -74.0060;
            var apiUrl = "https://api.openweathermap.org/data/2.5/forecast";

            _urlBuilder.BuildForecastApiUrl(latitude, longitude).Returns(apiUrl);
            _mockHttpMessageHandler.When(apiUrl).Respond("application/json", "{}");

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() =>
                _forecastService.GetForecastByCoordinatesAsync(latitude, longitude));
            Assert.Equal(WeatherApiErrorKind.InvalidResponse, exception.Kind);
        }

        [Fact]
        public async Task GetForecastByCoordinatesAsync_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var latitude = 40.7128;
            var longitude = -74.0060;
            var apiUrl = "https://api.openweathermap.org/data/2.5/forecast";

            _urlBuilder.BuildForecastApiUrl(latitude, longitude).Returns(apiUrl);
            _mockHttpMessageHandler.When(apiUrl).Respond("application/json", "{\"list\":[]}");

            // Act
            var result = await _forecastService.GetForecastByCoordinatesAsync(latitude, longitude);

            // Assert
            Assert.Empty(result);
        }
    }
}