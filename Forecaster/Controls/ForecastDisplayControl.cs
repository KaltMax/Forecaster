using Forecaster.Models.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Forecaster.Controls
{
    public partial class ForecastDisplayControl : UserControl
    {
        public ForecastDisplayControl()
        {
            InitializeComponent();
        }

        public void DisplayForecasts(List<ForecastInfo> forecasts)
        {
            // Clear existing forecast items
            forecastScrollPanel.Controls.Clear();

            if (forecasts == null || forecasts.Count == 0)
            {
                return;
            }

            const int itemWidth = 200;
            const int itemHeight = 200;
            const int itemSpacing = 10;
            int currentX = 10;

            foreach (var forecast in forecasts)
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
                Location = new Point(10, 115),
                Size = new Size(width - 20, 20),
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
    }
}