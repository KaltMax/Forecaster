using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forecaster.Models
{
    public class Forecast
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }
        [JsonPropertyName("main")]
        public Main Main { get; set; }
        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
    }
}
