using System.Collections.Generic;
using System.Threading.Tasks;
using Forecaster.Models;

namespace Forecaster.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherAsync(string cityName);
        Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double lat, double lon);
    }
}