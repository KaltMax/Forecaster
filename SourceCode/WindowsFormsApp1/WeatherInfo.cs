using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WeatherApp;

namespace WeatherApp
{
    internal class WeatherInfo
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

    internal class GeoInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    internal class WeatherResponse
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

    internal class Coord
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }

    internal class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("main")]
        public string Main { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    internal class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }
        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("sea_level")]
        public int SeaLevel { get; set; }
        [JsonPropertyName("grnd_level")]
        public int GrndLevel { get; set; }
    }

    internal class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("deg")]
        public int Deg { get; set; }
        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }

    internal class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }

    internal class Sys
    {
        [JsonPropertyName("type")]
        public int Type { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }

    internal class GeoResponse
    {
        [JsonPropertyName("results")]
        public List<GeoInfo> Results { get; set; }
    }
}

internal class ForecastInfo
{
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public string WeatherCondition { get; set; }
    public double WindSpeed { get; set; }
    public string Icon { get; set; }
    public long DateTime { get; set; }
}

internal class ForecastResponse
{
    [JsonPropertyName("list")]
    public List<Forecast> List { get; set; }
}

internal class Forecast
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