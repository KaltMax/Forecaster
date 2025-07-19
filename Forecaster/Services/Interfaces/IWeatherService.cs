using System.Threading.Tasks;
using Forecaster.Models.Domain;

namespace Forecaster.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherAsync(string cityName);
    }
}