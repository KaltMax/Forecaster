namespace Forecaster.Models
{
    public class ForecastInfo
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string WeatherCondition { get; set; }
        public double WindSpeed { get; set; }
        public string Icon { get; set; }
        public long DateTime { get; set; }
    }
}
