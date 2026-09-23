using Forecaster.Models.Domain;
using Forecaster.Services;
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

        public WeatherForecastForm(IWeatherService weatherService, IForecastService forecastService, IMessageBoxService messageBoxService,
            IWeatherIconService weatherIconService)
        {
            _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
            _messageBoxService = messageBoxService ?? throw new ArgumentNullException(nameof(messageBoxService));
            ArgumentNullException.ThrowIfNull(weatherIconService);
            InitializeComponent();

            weatherDisplayControl.SetIconService(weatherIconService);
            forecastDisplayControl.SetIconService(weatherIconService);
        }

        private void WeatherForecastForm_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            searchControl.FocusInput();
        }

        private async void searchControl_SearchRequested(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                _messageBoxService.ShowWarning("Please enter a city name.");
                return;
            }

            try
            {
                searchControl.SetLoadingState(true);
                Cursor = Cursors.WaitCursor;
                await LoadWeatherDataAsync(cityName);
            }
            catch (WeatherApiException ex)
            {
                // The message is already written for the user
                _messageBoxService.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                // Anything else is a bug. Async void must never let an exception escape
                _messageBoxService.ShowError($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                searchControl.SetLoadingState(false);
                Cursor = Cursors.Default;
            }
        }

        private async Task LoadWeatherDataAsync(string cityName)
        {
            WeatherInfo weatherInfo = await _weatherService.GetWeatherAsync(cityName);

            if (weatherInfo == null)
            {
                _messageBoxService.ShowWarning($"The city \"{cityName}\" could not be found. Please check the spelling and try again.");
                return;
            }

            weatherDisplayControl.DisplayWeather(weatherInfo);
            await LoadForecastDataAsync(weatherInfo);
        }

        private async Task LoadForecastDataAsync(WeatherInfo weatherInfo)
        {
            List<ForecastInfo> forecastInfos;
            try
            {
                forecastInfos = await _forecastService.GetForecastByCoordinatesAsync(weatherInfo.Latitude, weatherInfo.Longitude);
            }
            catch (WeatherApiException ex)
            {
                // The current weather is already shown, so remove the previous city's forecast instead of leaving it next to it
                forecastDisplayControl.DisplayForecasts(null);
                _messageBoxService.ShowError($"The current weather was loaded, but the forecast could not be loaded.\n\n{ex.Message}");
                return;
            }

            forecastDisplayControl.DisplayForecasts(forecastInfos);

            if (forecastInfos.Count == 0)
            {
                _messageBoxService.ShowWarning("No forecast data is available for this city.");
            }
        }
    }
}