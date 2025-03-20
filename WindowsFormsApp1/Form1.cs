using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeatherApp;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int _currentForecastIndex = 0;
        private List<ForecastInfo> _forecastInfos;

        public Form1()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            string cityName = tbCity.Text;
            if (!string.IsNullOrEmpty(cityName))
            {
                WeatherService weatherService = new WeatherService();
                WeatherInfo weatherInfo = await weatherService.GetWeatherAsync(cityName);

                if (weatherInfo != null)
                {
                    resultTemperature.Text = $@"{weatherInfo.Temperature} °C";
                    resultHumidity.Text = $@"{weatherInfo.Humidity}%";
                    resultWindspeed.Text = $@"{weatherInfo.WindSpeed} m/s";
                    weatherCondition.Text = weatherInfo.WeatherCondition;
                    resultSunrise.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunrise).ToString("HH:mm");
                    resultSunset.Text = DateTimeOffset.FromUnixTimeSeconds(weatherInfo.Sunset).ToString("HH:mm");

                    string iconUrl = $"http://openweathermap.org/img/wn/{weatherInfo.Icon}.png";
                    weatherPicture.Load(iconUrl);

                    _forecastInfos = await weatherService.GetForecastByCoordinatesAsync(weatherInfo.Latitude, weatherInfo.Longitude);

                    if (_forecastInfos != null && _forecastInfos.Count >= 3)
                    {
                        _currentForecastIndex = 0;

                        DisplayCurrentForecast();
                    }
                    else
                    {
                        MessageBox.Show("Forecast information could not be retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Weather information could not be retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a city name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DisplayCurrentForecast()
        {
            if (_forecastInfos == null || _forecastInfos.Count < 3)
                return;

            int maxIndex = _forecastInfos.Count - 1;

            DisplayForecast(_forecastInfos[_currentForecastIndex], pictureForecast1, weatherConditionForecast1, forecastResultTemperature1, forecastResultHumidity1, forecastResultWindspeed1, resultForecastTime1, resultForecastDate1);

            DisplayForecast(_forecastInfos[Math.Min(_currentForecastIndex + 1, maxIndex)], pictureForecast2, weatherConditionForecast2, forecastResultTemperature2, forecastResultHumidity2, forecastResultWindspeed2, resultForecastTime2, resultForecastDate2);

            DisplayForecast(_forecastInfos[Math.Min(_currentForecastIndex + 2, maxIndex)], pictureForecast3, weatherConditionForecast3, forecastResultTemperature3, forecastResultHumidity3, forecastResultWindspeed3, resultForecastTime3, resultForecastDate3);
        }

        private void DisplayForecast(ForecastInfo forecastInfo, PictureBox pictureBox, Label conditionLabel, Label temperatureLabel, Label humidityLabel, Label windspeedLabel, Label timeLabel, Label dateLabel)
        {
            dateLabel.Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime).ToString("dd.MM.yyyy");
            timeLabel.Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime).ToString("HH:mm");
            conditionLabel.Text = forecastInfo.WeatherCondition;
            temperatureLabel.Text = $@"{forecastInfo.Temperature} °C";
            humidityLabel.Text = $@"{forecastInfo.Humidity}%";
            windspeedLabel.Text = $@"{forecastInfo.WindSpeed} m/s";

            string iconUrl = $"http://openweathermap.org/img/wn/{forecastInfo.Icon}.png";
            pictureBox.Load(iconUrl);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (_forecastInfos != null && _currentForecastIndex + 3 < _forecastInfos.Count)
            {
                _currentForecastIndex += 3;
                DisplayCurrentForecast();
            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (_forecastInfos != null && _currentForecastIndex - 3 >= 0)
            {
                _currentForecastIndex -= 3;
                DisplayCurrentForecast();
            }
        }

        private void tbCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged_1(object sender, EventArgs e) { }

        private void label1_Click_1(object sender, EventArgs e) { }

        private void label1_Click_2(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void weatherDescription_Click(object sender, EventArgs e) { }

        private void resulstSunset_Click(object sender, EventArgs e) { }

        private void label1_Click_3(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }
    }
}
