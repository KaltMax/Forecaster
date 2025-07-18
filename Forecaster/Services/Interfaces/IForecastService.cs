using System.Collections.Generic;
using System.Threading.Tasks;
using Forecaster.Models;

namespace Forecaster.Services.Interfaces
{
    public interface IForecastService
    {
        Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double latitude, double longitude);
    }
}