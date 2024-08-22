# Forecaster - Weather App for Windows

## Description
This is a simple weather app that displays the weather forecast for a given city. The app uses the Open-Meteo API to get the weather data. The app displays the current weather, as well as the weather forecast for the next 5 days. The app also displays icons for the different weather conditions, such as sunny, cloudy, rainy, etc. The app is written in C# and uses Windows Forms for the user interface.

## Installation
Just download the project and extract the files. Open the 'Forecaster' directory and run the 'Forecaster.exe' file to start the app.

## Using the App
Pretty simple. Just enter the name of the city you want to get the weather forecast for and click the 'Get Weather' button. The app will display the current weather, as well as the weather forecast for the next 5 days. With the 'Next' and 'Previous' buttons you can navigate through the days. The app also displays icons for the different weather conditions.

## Using your own Open-Meteo API key
To use your own Open-Meteo API key, you need to replace the placeholders in the 'WeatherService.cs' file with your own API key. The placeholders are located in the 'GetGeoInfoAsync', 'GetWeatherByCoordinatesAsync' and 'GetForecastByCoordinatesAsync' methods. Replace the 'YOUR_API key' string with your own Open-Meteo API key and build the project.
