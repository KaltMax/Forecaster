using Forecaster.Models.Domain;
using Forecaster.Services;
using RichardSzalay.MockHttp;
using System.Net;

namespace Test.Services
{
    public class OpenWeatherMapHttpClientExtensionsTests
    {
        private const string ApiUrl = "https://api.openweathermap.org/geo/1.0/direct";

        private readonly MockHttpMessageHandler _mockHttpMessageHandler;
        private readonly HttpClient _httpClient;

        public OpenWeatherMapHttpClientExtensionsTests()
        {
            _mockHttpMessageHandler = new MockHttpMessageHandler();
            _httpClient = _mockHttpMessageHandler.ToHttpClient();
        }

        [Fact]
        public async Task GetFromOpenWeatherMapAsync_SuccessfulResponse_ReturnsDeserializedData()
        {
            // Arrange
            _mockHttpMessageHandler.When(ApiUrl).Respond("application/json", "[{\"name\":\"London\",\"lat\":51.5,\"lon\":-0.12,\"country\":\"GB\"}]");

            // Act
            var result = await _httpClient.GetFromOpenWeatherMapAsync<List<GeoInfo>>(ApiUrl);

            // Assert
            var geoInfo = Assert.Single(result);
            Assert.Equal("London", geoInfo.Name);
            Assert.Equal("GB", geoInfo.Country);
        }

        [Theory]
        [InlineData(HttpStatusCode.Unauthorized, WeatherApiErrorKind.InvalidApiKey)]
        [InlineData(HttpStatusCode.TooManyRequests, WeatherApiErrorKind.RateLimited)]
        [InlineData(HttpStatusCode.NotFound, WeatherApiErrorKind.ServiceError)]
        [InlineData(HttpStatusCode.InternalServerError, WeatherApiErrorKind.ServiceError)]
        [InlineData(HttpStatusCode.ServiceUnavailable, WeatherApiErrorKind.ServiceError)]
        public async Task GetFromOpenWeatherMapAsync_ErrorStatusCode_ThrowsMatchingErrorKind(HttpStatusCode statusCode, WeatherApiErrorKind expectedKind)
        {
            // Arrange
            _mockHttpMessageHandler.When(ApiUrl).Respond(statusCode);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() => _httpClient.GetFromOpenWeatherMapAsync<List<GeoInfo>>(ApiUrl));
            Assert.Equal(expectedKind, exception.Kind);
        }

        [Fact]
        public async Task GetFromOpenWeatherMapAsync_ConnectionFails_ThrowsNetworkError()
        {
            // Arrange
            _mockHttpMessageHandler.When(ApiUrl).Throw(new HttpRequestException("No such host is known."));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() => _httpClient.GetFromOpenWeatherMapAsync<List<GeoInfo>>(ApiUrl));
            Assert.Equal(WeatherApiErrorKind.NetworkError, exception.Kind);
            Assert.IsType<HttpRequestException>(exception.InnerException);
        }

        [Fact]
        public async Task GetFromOpenWeatherMapAsync_RequestTimesOut_ThrowsNetworkError()
        {
            // Arrange
            _httpClient.Timeout = TimeSpan.FromMilliseconds(50);
            _mockHttpMessageHandler.When(ApiUrl).Respond(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                return new HttpResponseMessage(HttpStatusCode.OK);
            });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() => _httpClient.GetFromOpenWeatherMapAsync<List<GeoInfo>>(ApiUrl));
            Assert.Equal(WeatherApiErrorKind.NetworkError, exception.Kind);
            Assert.IsAssignableFrom<TaskCanceledException>(exception.InnerException);
        }

        [Theory]
        [InlineData("{")]
        [InlineData("<html>Bad Gateway</html>")]
        [InlineData("null")]
        public async Task GetFromOpenWeatherMapAsync_UnreadableResponse_ThrowsInvalidResponseError(string body)
        {
            // Arrange
            _mockHttpMessageHandler.When(ApiUrl).Respond("application/json", body);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<WeatherApiException>(() => _httpClient.GetFromOpenWeatherMapAsync<List<GeoInfo>>(ApiUrl));
            Assert.Equal(WeatherApiErrorKind.InvalidResponse, exception.Kind);
        }

        [Theory]
        [InlineData(WeatherApiErrorKind.NetworkError, "internet connection")]
        [InlineData(WeatherApiErrorKind.InvalidApiKey, "API key")]
        [InlineData(WeatherApiErrorKind.RateLimited, "Too many requests")]
        public void WeatherApiException_Message_IsWrittenForTheUser(WeatherApiErrorKind kind, string expectedText)
        {
            // Act
            var exception = new WeatherApiException(kind);

            // Assert
            Assert.Contains(expectedText, exception.Message);
        }
    }
}
