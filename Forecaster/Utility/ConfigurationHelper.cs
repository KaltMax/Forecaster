using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Forecaster
{
    internal static class ConfigurationHelper
    {
        private static IConfiguration _configuration;

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