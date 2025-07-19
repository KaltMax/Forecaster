using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forecaster.Forms
{
    public partial class WeatherForecastForm : Form
    {
        private readonly IWeatherService _weatherService;
        private readonly IForecastService _forecastService;
        private readonly IMessageBoxService _messageBoxService;
        private List<ForecastInfo> _forecastInfos;

        public WeatherForecastForm(IWeatherService weatherService, IForecastService forecastService, IMessageBoxService messageBoxService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
            _messageBoxService = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));
            InitializeComponent();
        }

        private void WeatherForecastForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            tbCity.Focus();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            var cityName = tbCity.Text.Trim();
            if (string.IsNullOrEmpty(cityName))
            {
                _messageBoxService.ShowWarning("Please enter a city name.");
                return;
            }

            try
            {
                SetLoadingState(true);
                await LoadWeatherDataAsync(cityName);
            }
            catch (Exception ex)
            {
                _messageBoxService.ShowError($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                SetLoadingState(false);
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            searchButton.Enabled = !isLoading;
            searchButton.Text = isLoading ? "Loading..." : "Search";
            tbCity.Enabled = !isLoading;
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        }

        private async Task LoadWeatherDataAsync(string cityName)
        {
            try
            {
                WeatherInfo weatherInfo = await _weatherService.GetWeatherAsync(cityName);

                if (weatherInfo != null)
                {
                    DisplayWeatherInfo(weatherInfo);
                    await LoadForecastDataAsync(weatherInfo);
                }
                else
                {
                    _messageBoxService.ShowError("Weather information could not be retrieved. Please check the city name and try again.");
                }
            }
            catch (ArgumentException ex)
            {
                _messageBoxService.ShowWarning($"Invalid input: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                _messageBoxService.ShowError($"Service error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _messageBoxService.ShowError($"An unexpected error occurred while retrieving weather data: {ex.Message}");
            }
        }

        private void DisplayWeatherInfo(WeatherInfo weatherInfo)
        {
            resultCity.Text = weatherInfo.CityName;
            resultMeasurementTime.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.MeasurementTime).ToString("dd.MM.yyyy, HH:mm");
            resultTemperature.Text = $@"{weatherInfo.Temperature:F1} °C";
            resultHumidity.Text = $@"{weatherInfo.Humidity}%";
            resultWindspeed.Text = $@"{weatherInfo.WindSpeed:F1} m/s";
            weatherCondition.Text = weatherInfo.WeatherCondition;
            resultSunrise.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunrise).ToString("HH:mm");
            resultSunset.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunset).ToString("HH:mm");

            LoadWeatherIcon(weatherInfo.Icon);
        }

        private void LoadWeatherIcon(string iconCode)
        {
            try
            {
                var iconUrl = $"https://openweathermap.org/img/wn/{iconCode}.png";
                weatherPicture.Load(iconUrl);
            }
            catch
            {
                // Handle icon loading failure silently
                weatherPicture.Image = null;
            }
        }

        private async Task LoadForecastDataAsync(WeatherInfo weatherInfo)
        {
            try
            {
                _forecastInfos = await _forecastService.GetForecastByCoordinatesAsync(weatherInfo.Latitude, weatherInfo.Longitude);

                if (_forecastInfos is { Count: > 0 })
                {
                    DisplayAllForecasts();
                }
                else
                {
                    _messageBoxService.ShowError("Forecast information could not be retrieved. Please try again later.");
                }
            }
            catch (InvalidOperationException ex)
            {
                _messageBoxService.ShowError($"Forecast service error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _messageBoxService.ShowError($"An unexpected error occurred while retrieving forecast data: {ex.Message}");
            }
        }

        private void DisplayAllForecasts()
        {
            // Clear existing forecast items
            forecastScrollPanel.Controls.Clear();

            if (_forecastInfos == null || _forecastInfos.Count == 0)
            {
                return;
            }

            const int itemWidth = 200;
            const int itemHeight = 200;
            const int itemSpacing = 10;
            int currentX = 10;

            foreach (var forecast in _forecastInfos)
            {
                var forecastItem = CreateForecastItem(forecast, currentX, 10, itemWidth, itemHeight);
                forecastScrollPanel.Controls.Add(forecastItem);
                currentX += itemWidth + itemSpacing;
            }

            // Set the panel's auto-scroll size to accommodate all items
            forecastScrollPanel.AutoScrollMinSize = new Size(currentX, itemHeight + 20);
        }

        private Panel CreateForecastItem(ForecastInfo forecastInfo, int x, int y, int width, int height)
        {
            var itemPanel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.FromArgb(150, Color.LightGray),
                BorderStyle = BorderStyle.FixedSingle
            };

            var dateLabel = new Label
            {
                Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime).ToString("dd.MM.yyyy"),
                Font = new Font("Calibri", 11F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 5),
                Size = new Size(width - 20, 22),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var timeLabel = new Label
            {
                Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime).ToString("HH:mm"),
                Font = new Font("Calibri", 9F, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 27),
                Size = new Size(width - 20, 18),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var iconPictureBox = new PictureBox
            {
                Location = new Point((width - 60) / 2, 50),
                Size = new Size(60, 60),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(150, Color.LightGray),
            };

            LoadForecastIcon(iconPictureBox, forecastInfo.Icon);

            var conditionLabel = new Label
            {
                Text = forecastInfo.WeatherCondition,
                Font = new Font("Calibri", 9F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(5, 115),
                Size = new Size(width - 10, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var tempLabel = new Label
            {
                Text = $@"Temp: {forecastInfo.Temperature:F1} °C",
                Font = new Font("Calibri", 8F, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 140),
                Size = new Size(width - 20, 16)
            };

            var humidityLabel = new Label
            {
                Text = $@"Humidity: {forecastInfo.Humidity}%",
                Font = new Font("Calibri", 8F, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 158),
                Size = new Size(width - 20, 16)
            };

            var windLabel = new Label
            {
                Text = $@"Wind: {forecastInfo.WindSpeed:F1} m/s",
                Font = new Font("Calibri", 8F, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(10, 176),
                Size = new Size(width - 20, 16)
            };

            // Add all controls to the item panel
            itemPanel.Controls.AddRange(new Control[]
            {
                dateLabel, timeLabel, iconPictureBox, conditionLabel,
                tempLabel, humidityLabel, windLabel
            });

            return itemPanel;
        }

        private void LoadForecastIcon(PictureBox pictureBox, string iconCode)
        {
            try
            {
                var iconUrl = $"https://openweathermap.org/img/wn/{iconCode}.png";
                pictureBox.Load(iconUrl);
            }
            catch
            {
                // Handle icon loading failure silently
                pictureBox.Image = null;
            }
        }

        private void tbCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || string.IsNullOrWhiteSpace(tbCity.Text))
            {
                return;
            }

            searchButton.PerformClick();
            e.SuppressKeyPress = true;
        }
    }
}