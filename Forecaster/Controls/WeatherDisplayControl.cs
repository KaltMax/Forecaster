using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Forecaster.Controls
{
    public partial class WeatherDisplayControl : UserControl
    {
        private IWeatherIconService _iconService;
        private string _currentIconCode;

        public WeatherDisplayControl()
        {
            InitializeComponent();
        }

        public void SetIconService(IWeatherIconService iconService)
        {
            _iconService = iconService;
        }

        public void DisplayWeather(WeatherInfo weatherInfo)
        {
            resultCity.Text = weatherInfo.CityName;
            resultMeasurementTime.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.MeasurementTime)
                .ToLocalTime()
                .ToString("dddd, dd.MM.yyyy\nHH:mm", CultureInfo.InvariantCulture);
            resultTemperature.Text = $@"{weatherInfo.Temperature:F1} °C";
            resultHumidity.Text = $@"{weatherInfo.Humidity} %";
            resultWindspeed.Text = $@"{weatherInfo.WindSpeed:F1} m/s";
            weatherCondition.Text = weatherInfo.WeatherCondition;
            resultPressure.Text = $@"{weatherInfo.Pressure} hPa";
            resultSunrise.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunrise).ToLocalTime().ToString("HH:mm");
            resultSunset.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunset).ToLocalTime().ToString("HH:mm");
            LoadWeatherIcon(weatherInfo.Icon);
        }

        private async void LoadWeatherIcon(string iconCode)
        {
            _currentIconCode = iconCode;
            weatherPicture.Image = null;

            if (_iconService == null)
            {
                return;
            }

            try
            {
                var icon = await _iconService.GetIconAsync(iconCode);

                // Ignore the result if another search started while this icon was loading
                if (_currentIconCode == iconCode && !IsDisposed)
                {
                    weatherPicture.Image = icon;
                }
            }
            catch
            {
                // Handle icon loading failure silently
            }
        }
    }
}