using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Forecaster.Models
{
    public class GeoResponse
    {
        [JsonPropertyName("results")]
        public List<GeoInfo> Results { get; set; }
    }
}
