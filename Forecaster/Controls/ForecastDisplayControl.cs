using Forecaster.Models.Domain;
using Forecaster.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Forecaster.Controls
{
    public partial class ForecastDisplayControl : UserControl
    {
        // Shared by all forecast items instead of creating new fonts for every label
        private static readonly Font DateFont = new("Calibri", 11F, FontStyle.Bold);
        private static readonly Font TimeFont = new("Calibri", 10F, FontStyle.Regular);
        private static readonly Font ConditionFont = new("Calibri", 10F, FontStyle.Bold);
        private static readonly Font DetailFont = new("Calibri", 9F, FontStyle.Regular);

        private IWeatherIconService _iconService;

        public ForecastDisplayControl()
        {
            InitializeComponent();
        }

        public void SetIconService(IWeatherIconService iconService)
        {
            _iconService = iconService;
        }

        public void DisplayForecasts(List<ForecastInfo> forecasts)
        {
            ClearForecastItems();

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

        private void ClearForecastItems()
        {
            // Controls.Clear() only removes the items, so dispose them to release their window handles.
            // Disposing a PictureBox doesn't dispose its Image, so the shared cached icons stay usable.
            var oldItems = new Control[forecastScrollPanel.Controls.Count];
            forecastScrollPanel.Controls.CopyTo(oldItems, 0);
            forecastScrollPanel.Controls.Clear();

            foreach (var item in oldItems)
            {
                item.Dispose();
            }
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
                Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime)
                    .ToLocalTime()
                    .ToString("dddd, dd.MM.yyyy", CultureInfo.InvariantCulture),
                Font = DateFont,
                ForeColor = Color.Black,
                Location = new Point(10, 5),
                Size = new Size(width - 20, 22),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var timeLabel = new Label
            {
                Text = DateTimeOffset.FromUnixTimeSeconds(forecastInfo.DateTime).ToLocalTime().ToString("HH:mm"),
                Font = TimeFont,
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
                Font = ConditionFont,
                ForeColor = Color.Black,
                Location = new Point(10, 115),
                Size = new Size(width - 20, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var tempLabel = new Label
            {
                Text = $@"Temp:             {forecastInfo.Temperature:F1} °C",
                Font = DetailFont,
                ForeColor = Color.Black,
                Location = new Point(10, 140),
                Size = new Size(width - 20, 16)
            };

            var humidityLabel = new Label
            {
                Text = $@"Humidity:         {forecastInfo.Humidity} %",
                Font = DetailFont,
                ForeColor = Color.Black,
                Location = new Point(10, 158),
                Size = new Size(width - 20, 16)
            };

            var windLabel = new Label
            {
                Text = $@"Wind:             {forecastInfo.WindSpeed:F1} m/s",
                Font = DetailFont,
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

        private async void LoadForecastIcon(PictureBox pictureBox, string iconCode)
        {
            if (_iconService == null)
            {
                return;
            }

            try
            {
                var icon = await _iconService.GetIconAsync(iconCode);

                // The item may have been removed by a new search while the icon was loading
                if (!pictureBox.IsDisposed)
                {
                    pictureBox.Image = icon;
                }
            }
            catch
            {
                // Handle icon loading failure silently
            }
        }
    }
}