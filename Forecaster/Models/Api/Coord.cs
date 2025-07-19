using System.Text.Json.Serialization;

namespace Forecaster.Models.Api
{
    public class Coord
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
}
