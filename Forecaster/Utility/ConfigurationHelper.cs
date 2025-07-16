using Microsoft.Extensions.Configuration;
using System.IO;

namespace Forecaster.Utility
{
    internal static class ConfigurationHelper
    {
        private static readonly IConfiguration _configuration;

        static ConfigurationHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public static string GetApiKey()
        {
            return _configuration["ApiSettings:OpenWeatherMapApiKey"];
        }
    }
}