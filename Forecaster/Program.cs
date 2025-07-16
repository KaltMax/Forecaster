using System.Windows.Forms;
using Forecaster.Forms;

namespace Forecaster
{
    internal static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WeatherForecastForm());
        }
    }
}