using System.Threading.Tasks;
using Forecaster.Models;

namespace Forecaster.Services.Interfaces
{
    public interface IGeoInfoService
    {
        Task<GeoInfo> GetGeoInfoAsync(string cityName);
    }
}