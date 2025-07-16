using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forecaster.Models
{
    public class ForecastResponse
    {
        [JsonPropertyName("list")]
        public List<Forecast> List { get; set; }
    }
}
