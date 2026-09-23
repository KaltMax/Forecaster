using Forecaster.Models.Domain;
using System.Threading.Tasks;

namespace Forecaster.Services.Interfaces
{
    public interface IGeoInfoService
    {
        Task<GeoInfo> GetGeoInfoAsync(string cityName);
    }
}