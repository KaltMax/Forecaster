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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddHttpClient<IWeatherService, WeatherService>();
                    services.AddTransient<WeatherForecastForm>();
                    services.AddTransient<IMessageBoxService, MessageBoxService>();
                })
                .Build();

            using var scope = host.Services.CreateScope();
            var form = scope.ServiceProvider.GetRequiredService<WeatherForecastForm>();
            Application.Run(form);
        }
    }
}