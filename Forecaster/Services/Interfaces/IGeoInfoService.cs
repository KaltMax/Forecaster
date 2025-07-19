using System.Threading.Tasks;
using Forecaster.Models.Domain;

namespace Forecaster.Services.Interfaces
{
    public interface IGeoInfoService
    {
        Task<GeoInfo> GetGeoInfoAsync(string cityName);
    }
}