using System;

namespace Forecaster.Services
{
    /// <summary>
    /// Thrown when a request to OpenWeatherMap fails. The message is written for the user,
    /// while the technical cause is kept in <see cref="Exception.InnerException"/>.
    /// </summary>
    public class WeatherApiException : Exception
    {
        public WeatherApiErrorKind Kind { get; }

        public WeatherApiException(WeatherApiErrorKind kind, string detail = null, Exception innerException = null)
            : base(CreateMessage(kind, detail), innerException)
        {
            Kind = kind;
        }

        private static string CreateMessage(WeatherApiErrorKind kind, string detail)
        {
            return kind switch
            {
                WeatherApiErrorKind.NetworkError =>
                    "Could not connect to OpenWeatherMap. Please check your internet connection and try again.",
                WeatherApiErrorKind.InvalidApiKey =>
                    "OpenWeatherMap rejected the API key. Please check the key in appsettings.json. New keys can take a few hours to become active.",
                WeatherApiErrorKind.RateLimited =>
                    "Too many requests were sent to OpenWeatherMap. Please wait a moment and try again.",
                WeatherApiErrorKind.ServiceError =>
                    $"OpenWeatherMap returned an error{FormatDetail(detail)}. Please try again later.",
                WeatherApiErrorKind.InvalidResponse =>
                    $"OpenWeatherMap returned data that could not be read{FormatDetail(detail)}. Please try again later.",
                _ => "An unknown error occurred while contacting OpenWeatherMap."
            };
        }

        private static string FormatDetail(string detail)
        {
            return string.IsNullOrWhiteSpace(detail) ? string.Empty : $" ({detail})";
        }
    }
}
