using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Forecaster.Forms;
using Forecaster.Services;
using Forecaster.Services.Interfaces;

namespace Forecaster
{
    internal static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton(context.Configuration);
                    services.AddHttpClient<IWeatherService, WeatherService>();
                    services.AddTransient<IMessageBoxService, MessageBoxService>();
                    services.AddTransient<IOpenWeatherMapUrlBuilder, OpenWeatherMapUrlBuilder>();
                    services.AddHttpClient<IWeatherService, WeatherService>();
                    services.AddHttpClient<IForecastService, ForecastService>();
                    services.AddTransient<IGeoInfoService, GeoInfoService>();
                    services.AddTransient<WeatherForecastForm>();
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<WeatherForecastForm>();
            Application.Run(form);
        }
    }
}