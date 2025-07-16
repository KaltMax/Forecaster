using System.Text.Json.Serialization;

namespace Forecaster.Models
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }
}
