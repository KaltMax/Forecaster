using Forecaster.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forecaster.Models.Api
{
    public class WeatherResponse
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }
        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }
        [JsonPropertyName("main")]
        public Main Main { get; set; }
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }
        [JsonPropertyName("dt")]
        public long Dt { get; set; }
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }
}