using System.Windows.Forms;
using Forecaster.Controls;
using Forecaster.Models.Domain;

namespace Test.Controls
{
    public class ForecastDisplayControlTests
    {
        [Fact]
        public void DisplayForecasts_NullForecasts_ClearsControls()
        {
            // Arrange
            var control = new ForecastDisplayControl();

            // Act
            control.DisplayForecasts(null);

            // Assert
            Assert.Empty(control.Controls["forecastScrollPanel"]!.Controls);
        }

        [Fact]
        public void DisplayForecasts_EmptyForecasts_ClearsControls()
        {
            // Arrange
            var control = new ForecastDisplayControl();

            // Act
            control.DisplayForecasts(new List<ForecastInfo>());

            // Assert
            Assert.Empty(control.Controls["forecastScrollPanel"]!.Controls);
        }

        [Fact]
        public void DisplayForecasts_ValidForecasts_AddsCorrectNumberOfItems()
        {
            // Arrange
            var control = new ForecastDisplayControl();
            var forecasts = new List<ForecastInfo>
            {
                new ForecastInfo
                {
                    Temperature = 25.5,
                    Humidity = 60,
                    WeatherCondition = "Clear",
                    WindSpeed = 5.0,
                    Icon = "01d",
                    DateTime = 1625247600
                },
                new ForecastInfo
                {
                    Temperature = 18.3,
                    Humidity = 80,
                    WeatherCondition = "Rain",
                    WindSpeed = 3.2,
                    Icon = "09d",
                    DateTime = 1625334000
                }
            };

            // Act
            control.DisplayForecasts(forecasts);

            // Assert
            var scrollPanel = control.Controls["forecastScrollPanel"];
            Assert.NotNull(scrollPanel);
            Assert.Equal(2, scrollPanel.Controls.Count);
        }

        [Fact]
        public void DisplayForecasts_ValidForecasts_VerifiesItemContent()
        {
            // Arrange
            var control = new ForecastDisplayControl();
            var forecasts = new List<ForecastInfo>
            {
                new ForecastInfo
                {
                    Temperature = 25.5,
                    Humidity = 60,
                    WeatherCondition = "Clear",
                    WindSpeed = 5.0,
                    Icon = "01d",
                    DateTime = 1625247600
                }
            };

            // Act
            control.DisplayForecasts(forecasts);

            // Assert
            var scrollPanel = control.Controls["forecastScrollPanel"];
            var forecastItem = scrollPanel!.Controls[0] as Panel;
            Assert.NotNull(forecastItem);

            var labels = forecastItem.Controls.OfType<Label>().ToList();
            Assert.Contains(labels, l => l.Text == @"Temp:             25,5 °C");
            Assert.Contains(labels, l => l.Text == @"Humidity:         60 %");
            Assert.Contains(labels, l => l.Text == @"Clear");
        }
    }
}