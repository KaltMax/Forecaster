namespace Forecaster.Models.Domain
{
    public class WeatherInfo
    {
        public string CityName { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string WeatherCondition { get; set; }
        public double WindSpeed { get; set; }
        public string Icon { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long MeasurementTime { get; set; }
    }
}