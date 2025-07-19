using System.Collections.Generic;
using System.Threading.Tasks;
using Forecaster.Models.Domain;

namespace Forecaster.Services.Interfaces
{
    public interface IForecastService
    {
        Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double latitude, double longitude);
    }
}