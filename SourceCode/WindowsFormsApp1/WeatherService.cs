using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class WeatherService
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<WeatherInfo> GetWeatherAsync(string cityName)
        {
            var geoInfo = await GetGeoInfoAsync(cityName);
            if (geoInfo == null)
            {
                return null;
            }

            var weatherInfo = await GetWeatherByCoordinatesAsync(geoInfo.Latitude, geoInfo.Longitude);
            weatherInfo.CityName = geoInfo.Name;
            return weatherInfo;
        }

        private async Task<GeoInfo> GetGeoInfoAsync(string cityName)
        {
            string geoApiUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=1&appid=59b74c3580cd255f36583527bdc17c77";
            var response = await Client.GetStringAsync(geoApiUrl);
            var geoResponse = JsonSerializer.Deserialize<List<GeoInfo>>(response);

            if (geoResponse != null && geoResponse.Count > 0)
            {
                return geoResponse[0];
            }
            else
            {
                return null;
            }
        }

        private async Task<WeatherInfo> GetWeatherByCoordinatesAsync(double lat, double lon)
        {
            string weatherApiUrl = $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=59b74c3580cd255f36583527bdc17c77";
            var response = await Client.GetStringAsync(weatherApiUrl);
            var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(response);

            if (weatherResponse == null || weatherResponse.Main == null || weatherResponse.Weather == null || weatherResponse.Weather.Count == 0 || weatherResponse.Wind == null)
            {
                return null;
            }

            return new WeatherInfo
            {
                Latitude = lat,
                Longitude = lon,
                Temperature = weatherResponse.Main.Temp,
                Humidity = weatherResponse.Main.Humidity,
                WeatherCondition = weatherResponse.Weather[0].Description,
                WindSpeed = weatherResponse.Wind.Speed,
                CityName = weatherResponse.Name,
                Icon = weatherResponse.Weather[0].Icon,
                Sunrise = weatherResponse.Sys.Sunrise,
                Sunset = weatherResponse.Sys.Sunset
            };
        }

        public async Task<List<ForecastInfo>> GetForecastByCoordinatesAsync(double lat, double lon)
        {
            string forecastApiUrl = $"http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&units=metric&appid=59b74c3580cd255f36583527bdc17c77";
            var response = await Client.GetStringAsync(forecastApiUrl);
            var forecastResponse = JsonSerializer.Deserialize<ForecastResponse>(response);

            if (forecastResponse == null || forecastResponse.List == null || forecastResponse.List.Count < 4)
            {
                return null;
            }

            var forecastInfos = new List<ForecastInfo>();
            for (int i = 1; i < forecastResponse.List.Count; i++)
            {
                var forecast = forecastResponse.List[i];
                forecastInfos.Add(new ForecastInfo
                {
                    Temperature = forecast.Main.Temp,
                    Humidity = forecast.Main.Humidity,
                    WeatherCondition = forecast.Weather[0].Description,
                    WindSpeed = forecast.Wind.Speed,
                    Icon = forecast.Weather[0].Icon,
                    DateTime = forecast.Dt
                });
            }
            return forecastInfos;
        }
    }
}
