using Forecaster.Controls;
using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using NSubstitute;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

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

            // Act (pin the culture so decimal formatting doesn't depend on the machine)
            var originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo("de-AT");
            try
            {
                control.DisplayForecasts(forecasts);
            }
            finally
            {
                CultureInfo.CurrentCulture = originalCulture;
            }

            // Assert
            var scrollPanel = control.Controls["forecastScrollPanel"];
            var forecastItem = scrollPanel!.Controls[0] as Panel;
            Assert.NotNull(forecastItem);

            var labels = forecastItem.Controls.OfType<Label>().ToList();
            Assert.Contains(labels, l => l.Text == @"Temp:             25,5 °C");
            Assert.Contains(labels, l => l.Text == @"Humidity:         60 %");
            Assert.Contains(labels, l => l.Text == @"Clear");
        }

        [Fact]
        public void DisplayForecasts_WithIconService_SetsIconOfEachItem()
        {
            // Arrange
            var control = new ForecastDisplayControl();
            using var sunIcon = new Bitmap(1, 1);
            using var rainIcon = new Bitmap(1, 1);
            var iconService = Substitute.For<IWeatherIconService>();
            iconService.GetIconAsync("01d").Returns(sunIcon);
            iconService.GetIconAsync("09d").Returns(rainIcon);
            control.SetIconService(iconService);

            var forecasts = new List<ForecastInfo>
            {
                new ForecastInfo { Icon = "01d", DateTime = 1625247600 },
                new ForecastInfo { Icon = "09d", DateTime = 1625258400 }
            };

            // Act
            control.DisplayForecasts(forecasts);

            // Assert
            var items = control.Controls["forecastScrollPanel"]!.Controls.OfType<Panel>().ToList();
            Assert.Same(sunIcon, items[0].Controls.OfType<PictureBox>().Single().Image);
            Assert.Same(rainIcon, items[1].Controls.OfType<PictureBox>().Single().Image);
        }

        [Fact]
        public void DisplayForecasts_AfterScrollingRight_StartsNewForecastsAtTheBeginning()
        {
            // Arrange: scrolling only works once the panel has a window handle
            var control = new ForecastDisplayControl();
            var scrollPanel = (Panel)control.Controls["forecastScrollPanel"]!;
            _ = control.Handle;
            _ = scrollPanel.Handle;

            var forecasts = Enumerable.Range(0, 40).Select(_ => new ForecastInfo()).ToList();
            control.DisplayForecasts(forecasts);
            scrollPanel.AutoScrollPosition = new Point(2000, 0);
            Assert.NotEqual(0, scrollPanel.AutoScrollPosition.X);

            // Act
            control.DisplayForecasts(forecasts);

            // Assert
            Assert.Equal(Point.Empty, scrollPanel.AutoScrollPosition);
            Assert.Equal(10, scrollPanel.Controls[0].Left);
        }

        [Fact]
        public void DisplayForecasts_CalledAgain_DisposesPreviousItems()
        {
            // Arrange
            var control = new ForecastDisplayControl();
            control.DisplayForecasts(new List<ForecastInfo> { new ForecastInfo(), new ForecastInfo() });
            var oldItems = control.Controls["forecastScrollPanel"]!.Controls.OfType<Panel>().ToList();

            // Act
            control.DisplayForecasts(new List<ForecastInfo> { new ForecastInfo() });

            // Assert
            Assert.All(oldItems, item => Assert.True(item.IsDisposed));
            Assert.All(oldItems.SelectMany(item => item.Controls.Cast<Control>()), child => Assert.True(child.IsDisposed));
            Assert.Single(control.Controls["forecastScrollPanel"]!.Controls);
        }

        [Fact]
        public void DisplayForecasts_CalledAgain_KeepsSharedIconUsable()
        {
            // Arrange
            var control = new ForecastDisplayControl();
            using var icon = new Bitmap(4, 3);
            var iconService = Substitute.For<IWeatherIconService>();
            iconService.GetIconAsync("01d").Returns(icon);
            control.SetIconService(iconService);
            var forecasts = new List<ForecastInfo> { new ForecastInfo { Icon = "01d" } };

            // Act
            control.DisplayForecasts(forecasts);
            control.DisplayForecasts(forecasts);

            // Assert: a disposed Bitmap throws when its size is read
            Assert.Equal(new Size(4, 3), icon.Size);
            var newItem = control.Controls["forecastScrollPanel"]!.Controls.OfType<Panel>().Single();
            Assert.Same(icon, newItem.Controls.OfType<PictureBox>().Single().Image);
        }
    }
}