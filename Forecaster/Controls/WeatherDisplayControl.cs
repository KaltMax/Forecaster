using Forecaster.Models.Domain;
using System;
using System.Windows.Forms;

namespace Forecaster.Controls
{
    public partial class WeatherDisplayControl : UserControl
    {
        public WeatherDisplayControl()
        {
            InitializeComponent();
        }

        public void DisplayWeather(WeatherInfo weatherInfo)
        {
            resultCity.Text = weatherInfo.CityName;
            resultMeasurementTime.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.MeasurementTime).ToLocalTime().ToString("dd.MM.yyyy, HH:mm");
            resultTemperature.Text = $@"{weatherInfo.Temperature:F1} °C";
            resultHumidity.Text = $@"{weatherInfo.Humidity} %";
            resultWindspeed.Text = $@"{weatherInfo.WindSpeed:F1} m/s";
            weatherCondition.Text = weatherInfo.WeatherCondition;
            resultPressure.Text = $@"{weatherInfo.Pressure} hPa";
            resultSunrise.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunrise).ToLocalTime().ToString("HH:mm");
            resultSunset.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunset).ToLocalTime().ToString("HH:mm");
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
    }
}