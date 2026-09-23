using Forecaster.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forecaster.Services
{
    public class WeatherIconService : IWeatherIconService
    {
        public const string HttpClientName = nameof(WeatherIconService);
        private const string IconBaseUrl = "https://openweathermap.org/img/wn/";

        private readonly IHttpClientFactory _httpClientFactory;

        // Caches the download task per icon code, so concurrent requests for the same icon share one download
        private readonly ConcurrentDictionary<string, Task<Image>> _cache = new();

        public WeatherIconService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<Image> GetIconAsync(string iconCode)
        {
            if (string.IsNullOrWhiteSpace(iconCode))
            {
                return null;
            }

            var downloadTask = _cache.GetOrAdd(iconCode, DownloadIconAsync);
            var icon = await downloadTask;

            if (icon == null)
            {
                // Don't cache failures, so the icon is retried on the next search
                _cache.TryRemove(new KeyValuePair<string, Task<Image>>(iconCode, downloadTask));
            }

            return icon;
        }

        private async Task<Image> DownloadIconAsync(string iconCode)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(HttpClientName);
                var bytes = await httpClient.GetByteArrayAsync($"{IconBaseUrl}{Uri.EscapeDataString(iconCode)}.png");

                // Copy into a new Bitmap, because an Image created from a stream needs that stream to stay open
                using var stream = new MemoryStream(bytes);
                using var image = Image.FromStream(stream);
                return new Bitmap(image);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
