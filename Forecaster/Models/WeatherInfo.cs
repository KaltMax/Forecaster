using System.Text.Json.Serialization;

namespace Forecaster.Models
{
    public class WeatherInfo
    {
        [JsonPropertyName("name")]
        public string CityName { get; set; }
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
        [JsonPropertyName("description")]
        public string WeatherCondition { get; set; }
        [JsonPropertyName("speed")]
        public double WindSpeed { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
