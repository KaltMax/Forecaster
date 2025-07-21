using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forecaster.Forms
{
    public partial class WeatherForecastForm : Form
    {
        private readonly IWeatherService _weatherService;
        private readonly IForecastService _forecastService;
        private readonly IMessageBoxService _messageBoxService;

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
                    weatherDisplayControl.DisplayWeather(weatherInfo);
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

        private async Task LoadForecastDataAsync(WeatherInfo weatherInfo)
        {
            try
            {
                List<ForecastInfo> forecastInfos = await _forecastService.GetForecastByCoordinatesAsync(weatherInfo.Latitude, weatherInfo.Longitude);

                if (forecastInfos is { Count: > 0 })
                {
                    forecastDisplayControl.DisplayForecasts(forecastInfos);
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