namespace Forecaster.Services
{
    public enum WeatherApiErrorKind
    {
        /// <summary>OpenWeatherMap could not be reached, or the request timed out.</summary>
        NetworkError,

        /// <summary>OpenWeatherMap rejected the API key (HTTP 401).</summary>
        InvalidApiKey,

        /// <summary>Too many requests were sent to OpenWeatherMap (HTTP 429).</summary>
        RateLimited,

        /// <summary>OpenWeatherMap answered with any other error status code.</summary>
        ServiceError,

        /// <summary>The response could not be read or is missing required data.</summary>
        InvalidResponse
    }
}
