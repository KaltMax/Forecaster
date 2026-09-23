using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Forecaster.Forms;
using Forecaster.Services;
using Forecaster.Services.Interfaces;

namespace Forecaster
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load appsettings.json from the exe's folder, not the current working directory
            using var host = Host.CreateDefaultBuilder()
                .UseContentRoot(AppContext.BaseDirectory)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton(context.Configuration);
                    services.AddTransient<IMessageBoxService, MessageBoxService>();
                    services.AddTransient<IOpenWeatherMapUrlBuilder, OpenWeatherMapUrlBuilder>();
                    services.AddHttpClient<IWeatherService, WeatherService>();
                    services.AddHttpClient<IForecastService, ForecastService>();
                    services.AddHttpClient<IGeoInfoService, GeoInfoService>();
                    services.AddHttpClient(WeatherIconService.HttpClientName);
                    services.AddSingleton<IWeatherIconService, WeatherIconService>();
                    services.AddTransient<WeatherForecastForm>();
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<WeatherForecastForm>();
            Application.Run(form);
        }
    }
}