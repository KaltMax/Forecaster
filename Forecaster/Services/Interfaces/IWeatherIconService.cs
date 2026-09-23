using System.Drawing;
using System.Threading.Tasks;

namespace Forecaster.Services.Interfaces
{
    public interface IWeatherIconService
    {
        /// <summary>
        /// Returns the OpenWeatherMap icon for the given code, or null if it could not be loaded.
        /// The returned image is cached and shared, so callers must not dispose it.
        /// </summary>
        Task<Image> GetIconAsync(string iconCode);
    }
}
