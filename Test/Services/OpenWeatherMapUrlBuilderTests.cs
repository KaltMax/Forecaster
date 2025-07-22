using Microsoft.Extensions.Configuration;
using Forecaster.Services;

namespace Test.Services
{
    public class OpenWeatherMapUrlBuilderTests
    {
        private readonly OpenWeatherMapUrlBuilder _urlBuilder;

        public OpenWeatherMapUrlBuilderTests()
        {
            // Mock configuration with a valid API key
            var inMemorySettings = new Dictionary<string, string>
            {
                { "ApiSettings:OpenWeatherMapApiKey", "test-api-key" }
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();

            _urlBuilder = new OpenWeatherMapUrlBuilder(configuration);
        }

        [Fact]
        public void BuildGeoApiUrl_ValidCityName_ReturnsCorrectUrl()
        {
            // Arrange
            string cityName = "London";

            // Act
            string result = _urlBuilder.BuildGeoApiUrl(cityName);

            // Assert
            Assert.Equal("https://api.openweathermap.org/geo/1.0/direct?q=London&limit=1&appid=test-api-key", result);
        }

        [Fact]
        public void BuildGeoApiUrl_EmptyCityName_ThrowsArgumentException()
        {
            // Arrange
            string cityName = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _urlBuilder.BuildGeoApiUrl(cityName));
        }

        [Fact]
        public void BuildWeatherApiUrl_ValidCoordinates_ReturnsCorrectUrl()
        {
            // Arrange
            double latitude = 51.5074;
            double longitude = -0.1278;

            // Act
            string result = _urlBuilder.BuildWeatherApiUrl(latitude, longitude);

            // Assert
            Assert.Equal("https://api.openweathermap.org/data/2.5/weather?lat=51,507400&lon=-0,127800&units=metric&appid=test-api-key", result);
        }

        [Fact]
        public void BuildForecastApiUrl_ValidCoordinates_ReturnsCorrectUrl()
        {
            // Arrange
            double latitude = 51.5074;
            double longitude = -0.1278;

            // Act
            string result = _urlBuilder.BuildForecastApiUrl(latitude, longitude);

            // Assert
            Assert.Equal("https://api.openweathermap.org/data/2.5/forecast?lat=51,507400&lon=-0,127800&units=metric&appid=test-api-key", result);
        }

        [Fact]
        public void Constructor_MissingApiKey_ThrowsInvalidOperationException()
        {
            // Arrange
            IConfiguration configuration = new ConfigurationBuilder().Build();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => new OpenWeatherMapUrlBuilder(configuration));
        }
    }
}