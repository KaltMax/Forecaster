using Forecaster.Controls;
using Forecaster.Models.Domain;
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

            // Convert timestamps to UTC+2
            var testTimeZone = TimeZoneInfo.CreateCustomTimeZone("UTC+2", TimeSpan.FromHours(2), "UTC+2", "UTC+2");
            var measurementTime = TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeSeconds(weatherInfo.MeasurementTime), testTimeZone);
            var sunriseTime = TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunrise), testTimeZone);
            var sunsetTime = TimeZoneInfo.ConvertTime(DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunset), testTimeZone);

            // Act
            control.DisplayWeather(weatherInfo);

            // Assert
            Assert.Equal("New York", control.Controls["resultCity"]!.Text);
            Assert.Equal(measurementTime.ToString("dd.MM.yyyy, HH:mm"), control.Controls["resultMeasurementTime"]!.Text);
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
    }
}