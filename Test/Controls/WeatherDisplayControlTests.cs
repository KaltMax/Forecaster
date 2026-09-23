using Forecaster.Controls;
using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using NSubstitute;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Test.Controls
{
    public class WeatherDisplayControlTests
    {
        [Fact]
        public void DisplayWeather_ValidWeatherInfo_UpdatesUIElements()
        {
            // Arrange
            var control = new WeatherDisplayControl();
            var weatherInfo = new WeatherInfo
            {
                CityName = "New York",
                Temperature = 25.5,
                Humidity = 60,
                Pressure = 1013,
                WeatherCondition = "Clear",
                WindSpeed = 5.0,
                Icon = "01d",
                Sunrise = 1625205600,
                Sunset = 1625256000,
                MeasurementTime = 1625247600
            };

            // The control shows times in the machine's local time zone, so the expected values must too
            var measurementTime = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.MeasurementTime).ToLocalTime();
            var sunriseTime = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunrise).ToLocalTime();
            var sunsetTime = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunset).ToLocalTime();

            // Act (pin the culture so decimal formatting doesn't depend on the machine)
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo("de-AT");
            try
            {
                control.DisplayWeather(weatherInfo);
            }
            finally
            {
                CultureInfo.CurrentCulture = originalCulture;
            }

            // Assert
            Assert.Equal("New York", control.Controls["resultCity"]!.Text);
            Assert.Equal(measurementTime.ToString("dddd, dd.MM.yyyy\nHH:mm", CultureInfo.InvariantCulture), control.Controls["resultMeasurementTime"]!.Text);
            Assert.Equal("25,5 °C", control.Controls["resultTemperature"]!.Text);
            Assert.Equal("60 %", control.Controls["resultHumidity"]!.Text);
            Assert.Equal("5,0 m/s", control.Controls["resultWindspeed"]!.Text);
            Assert.Equal("Clear", control.Controls["weatherCondition"]!.Text);
            Assert.Equal("1013 hPa", control.Controls["resultPressure"]!.Text);
            Assert.Equal(sunriseTime.ToString("HH:mm"), control.Controls["resultSunrise"]!.Text);
            Assert.Equal(sunsetTime.ToString("HH:mm"), control.Controls["resultSunset"]!.Text);
        }

        [Fact]
        public void DisplayWeather_InvalidIcon_SetsWeatherPictureToNull()
        {
            // Arrange
            var control = new WeatherDisplayControl();
            var iconService = Substitute.For<IWeatherIconService>();
            iconService.GetIconAsync("invalid_icon").Returns((Image?)null);
            control.SetIconService(iconService);

            var weatherInfo = new WeatherInfo
            {
                Icon = "invalid_icon"
            };

            // Act
            control.DisplayWeather(weatherInfo);

            // Assert
            var weatherPicture = control.Controls["weatherPicture"] as PictureBox;
            Assert.NotNull(weatherPicture);
            Assert.Null(weatherPicture!.Image);
        }

        [Fact]
        public void DisplayWeather_ValidIcon_SetsWeatherPictureFromIconService()
        {
            // Arrange
            var control = new WeatherDisplayControl();
            using var icon = new Bitmap(1, 1);
            var iconService = Substitute.For<IWeatherIconService>();
            iconService.GetIconAsync("01d").Returns(icon);
            control.SetIconService(iconService);

            // Act
            control.DisplayWeather(new WeatherInfo { Icon = "01d" });

            // Assert
            var weatherPicture = control.Controls["weatherPicture"] as PictureBox;
            Assert.Same(icon, weatherPicture!.Image);
        }
    }
}