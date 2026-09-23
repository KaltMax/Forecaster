using Forecaster.Services;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace Test.Services
{
    public class WeatherIconServiceTests
    {
        private const string SunIconUrl = "https://openweathermap.org/img/wn/01d.png";

        private readonly MockHttpMessageHandler _mockHttpMessageHandler;
        private readonly WeatherIconService _iconService;

        public WeatherIconServiceTests()
        {
            _mockHttpMessageHandler = new MockHttpMessageHandler();
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            httpClientFactory.CreateClient(Arg.Any<string>()).Returns(_ => _mockHttpMessageHandler.ToHttpClient());
            _iconService = new WeatherIconService(httpClientFactory);
        }

        [Fact]
        public async Task GetIconAsync_ValidIconCode_ReturnsImage()
        {
            // Arrange
            _mockHttpMessageHandler.When(SunIconUrl).Respond(_ => PngResponse(width: 4, height: 3));

            // Act
            var icon = await _iconService.GetIconAsync("01d");

            // Assert
            Assert.NotNull(icon);
            Assert.Equal(new Size(4, 3), icon.Size);
        }

        [Fact]
        public async Task GetIconAsync_SameIconCodeTwice_DownloadsOnlyOnce()
        {
            // Arrange
            var request = _mockHttpMessageHandler.When(SunIconUrl).Respond(_ => PngResponse(width: 1, height: 1));

            // Act
            var first = await _iconService.GetIconAsync("01d");
            var second = await _iconService.GetIconAsync("01d");

            // Assert
            Assert.Same(first, second);
            Assert.Equal(1, _mockHttpMessageHandler.GetMatchCount(request));
        }

        [Fact]
        public async Task GetIconAsync_DownloadFails_ReturnsNullAndRetriesNextTime()
        {
            // Arrange
            var request = _mockHttpMessageHandler.When(SunIconUrl).Respond(HttpStatusCode.NotFound);

            // Act
            var first = await _iconService.GetIconAsync("01d");
            var second = await _iconService.GetIconAsync("01d");

            // Assert
            Assert.Null(first);
            Assert.Null(second);
            Assert.Equal(2, _mockHttpMessageHandler.GetMatchCount(request));
        }

        [Fact]
        public async Task GetIconAsync_ResponseIsNotAnImage_ReturnsNull()
        {
            // Arrange
            _mockHttpMessageHandler.When(SunIconUrl).Respond("text/html", "<html>not an image</html>");

            // Act
            var icon = await _iconService.GetIconAsync("01d");

            // Assert
            Assert.Null(icon);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task GetIconAsync_EmptyIconCode_ReturnsNullWithoutRequest(string? iconCode)
        {
            // Arrange
            var anyRequest = _mockHttpMessageHandler.When("*").Respond(HttpStatusCode.OK);

            // Act
            var icon = await _iconService.GetIconAsync(iconCode!);

            // Assert
            Assert.Null(icon);
            Assert.Equal(0, _mockHttpMessageHandler.GetMatchCount(anyRequest));
        }

        private static HttpResponseMessage PngResponse(int width, int height)
        {
            using var bitmap = new Bitmap(width, height);
            using var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
        }
    }
}
