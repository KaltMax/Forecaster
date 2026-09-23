using Forecaster.Models.Domain;
using System.Threading.Tasks;

namespace Forecaster.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherAsync(string cityName);
    }
}