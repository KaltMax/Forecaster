using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forecaster.Models.Api
{
    public class ForecastResponse
    {
        [JsonPropertyName("list")]
        public List<Forecast> List { get; set; }
    }
}
