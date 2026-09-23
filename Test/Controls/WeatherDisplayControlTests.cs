using Forecaster.Controls;
using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using NSubstitute;
using System.Drawing;
using System.Globalization;
using System.Reflection;
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
                MeasurementTime = 1625247600,
                TimezoneOffsetSeconds = -4 * 3600
            };

            // The measurement time is shown in the machine's local time zone, so the expected value must be too
            var measurementTime = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.MeasurementTime).ToLocalTime();

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
            // Sunrise 06:00 UTC and sunset 20:00 UTC, shown in the city's time (UTC-4)
            Assert.Equal("02:00 (local)", control.Controls["resultSunrise"]!.Text);
            Assert.Equal("16:00 (local)", control.Controls["resultSunset"]!.Text);
        }

        [Theory]
        [InlineData(0, "Time in London, GB (UTC)")]
        [InlineData(9 * 3600, "Time in London, GB (UTC+9)")]
        [InlineData(-4 * 3600, "Time in London, GB (UTC-4)")]
        [InlineData(5 * 3600 + 30 * 60, "Time in London, GB (UTC+5:30)")]
        [InlineData(-(3 * 3600 + 30 * 60), "Time in London, GB (UTC-3:30)")]
        public void DisplayWeather_SetsTimeZoneToolTipOnSunTimes(int timezoneOffsetSeconds, string expectedToolTip)
        {
            // Arrange
            var control = new WeatherDisplayControl();
            var weatherInfo = new WeatherInfo { CityName = "London, GB", TimezoneOffsetSeconds = timezoneOffsetSeconds };

            // Act
            control.DisplayWeather(weatherInfo);

            // Assert
            var toolTip = GetToolTip(control);
            Assert.Equal(expectedToolTip, toolTip.GetToolTip(control.Controls["resultSunrise"]));
            Assert.Equal(expectedToolTip, toolTip.GetToolTip(control.Controls["resultSunset"]));
        }

        [Fact]
        public void DisplayWeather_SunTimeCrossesMidnight_ShowsCityTime()
        {
            // Arrange: sunset at 20:00 UTC is 05:00 the next day in Tokyo (UTC+9)
            var control = new WeatherDisplayControl();
            var weatherInfo = new WeatherInfo { Sunset = 1625256000, TimezoneOffsetSeconds = 9 * 3600 };

            // Act
            control.DisplayWeather(weatherInfo);

            // Assert
            Assert.Equal("05:00 (local)", control.Controls["resultSunset"]!.Text);
        }

        // The ToolTip is a designer component, not a child control, so it can only be reached through its field
        private static ToolTip GetToolTip(WeatherDisplayControl control) =>
            (ToolTip)typeof(WeatherDisplayControl)
                .GetField("toolTip", BindingFlags.NonPublic | BindingFlags.Instance)!
                .GetValue(control)!;

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