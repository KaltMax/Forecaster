using Forecaster.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forecaster.Services.Interfaces
{
    public interface IForecastService
    {
        Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double latitude, double longitude);
    }
}