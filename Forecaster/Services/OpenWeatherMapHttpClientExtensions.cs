using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forecaster.Services
{
    public static class OpenWeatherMapHttpClientExtensions
    {
        /// <summary>
        /// Sends a GET request to OpenWeatherMap and deserializes the JSON response.
        /// Every failure is reported as a <see cref="WeatherApiException"/> with a matching <see cref="WeatherApiErrorKind"/>.
        /// </summary>
        public static async Task<T> GetFromOpenWeatherMapAsync<T>(this HttpClient httpClient, string url)
        {
            HttpResponseMessage response;
            try
            {
                response = await httpClient.GetAsync(url);
            }
            catch (HttpRequestException ex)
            {
                throw new WeatherApiException(WeatherApiErrorKind.NetworkError, innerException: ex);
            }
            catch (TaskCanceledException ex)
            {
                // No cancellation token is passed, so a cancelled request means the HttpClient timeout elapsed
                throw new WeatherApiException(WeatherApiErrorKind.NetworkError, innerException: ex);
            }

            using (response)
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new WeatherApiException(GetErrorKind(response.StatusCode), $"HTTP {(int)response.StatusCode}");
                }

                try
                {
                    return await response.Content.ReadFromJsonAsync<T>()
                        ?? throw new WeatherApiException(WeatherApiErrorKind.InvalidResponse, "empty response");
                }
                catch (JsonException ex)
                {
                    throw new WeatherApiException(WeatherApiErrorKind.InvalidResponse, innerException: ex);
                }
            }
        }

        private static WeatherApiErrorKind GetErrorKind(HttpStatusCode statusCode)
        {
            return statusCode switch
            {
                HttpStatusCode.Unauthorized => WeatherApiErrorKind.InvalidApiKey,
                HttpStatusCode.TooManyRequests => WeatherApiErrorKind.RateLimited,
                _ => WeatherApiErrorKind.ServiceError
            };
        }
    }
}
