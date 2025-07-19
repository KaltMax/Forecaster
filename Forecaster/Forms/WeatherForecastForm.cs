using Forecaster.Models;
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
        private int _currentForecastIndex;
        private List<ForecastInfo> _forecastInfos;
        private const int ForecastsPerPage = 3;

        public WeatherForecastForm(IWeatherService weatherService, IForecastService forecastService, IMessageBoxService messageBoxService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
            _messageBoxService = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void WeatherForecastForm_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(1280, 720);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            // Set initial navigation button states
            UpdateNavigationButtons();
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
            nextButton.Enabled = !isLoading && CanNavigateNext();
            prevButton.Enabled = !isLoading && CanNavigatePrevious();
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

                if (_forecastInfos is { Count: >= 3 })
                {
                    _currentForecastIndex = 0;
                    DisplayCurrentForecast();
                    UpdateNavigationButtons();
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

        private void DisplayCurrentForecast()
        {
            if (_forecastInfos == null || _forecastInfos.Count < 3)
            {
                return;
            }

            var maxIndex = _forecastInfos.Count - 1;

            DisplayForecast(_forecastInfos[_currentForecastIndex], pictureForecast1, weatherConditionForecast1, forecastResultTemperature1, forecastResultHumidity1, forecastResultWindspeed1, resultForecastTime1, resultForecastDate1);

            DisplayForecast(_forecastInfos[Math.Min(_currentForecastIndex + 1, maxIndex)], pictureForecast2, weatherConditionForecast2, forecastResultTemperature2, forecastResultHumidity2, forecastResultWindspeed2, resultForecastTime2, resultForecastDate2);

            DisplayForecast(_forecastInfos[Math.Min(_currentForecastIndex + 2, maxIndex)], pictureForecast3, weatherConditionForecast3, forecastResultTemperature3, forecastResultHumidity3, forecastResultWindspeed3, resultForecastTime3, resultForecastDate3);
        }

        private void DisplayForecast(ForecastInfo forecastInfo, PictureBox pictureBox, Label conditionLabel, Label temperatureLabel, Label humidityLabel, Label windspeedLabel, Label timeLabel, Label dateLabel)
        {
            dateLabel.Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime).ToString("dd.MM.yyyy");
            timeLabel.Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime).ToString("HH:mm");
            conditionLabel.Text = forecastInfo.WeatherCondition;
            temperatureLabel.Text = $@"{forecastInfo.Temperature:F1} °C";
            humidityLabel.Text = $@"{forecastInfo.Humidity}%";
            windspeedLabel.Text = $@"{forecastInfo.WindSpeed:F1} m/s";

            LoadForecastIcon(pictureBox, forecastInfo.Icon);
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

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!CanNavigateNext())
            {
                return;
            }

            _currentForecastIndex += ForecastsPerPage;
            DisplayCurrentForecast();
            UpdateNavigationButtons();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (!CanNavigatePrevious())
            {
                return;
            }

            _currentForecastIndex -= ForecastsPerPage;
            DisplayCurrentForecast();
            UpdateNavigationButtons();
        }

        private bool CanNavigateNext() =>
            _forecastInfos != null && _currentForecastIndex + ForecastsPerPage < _forecastInfos.Count;

        private bool CanNavigatePrevious() =>
            _forecastInfos != null && _currentForecastIndex - ForecastsPerPage >= 0;

        private void UpdateNavigationButtons()
        {
            nextButton.Enabled = CanNavigateNext();
            prevButton.Enabled = CanNavigatePrevious();
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