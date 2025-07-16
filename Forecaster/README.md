# Forecaster - Weather App for Windows

## Description
This is a simple weather app that displays the weather forecast for a given city. The app uses the OpenWeatherMap API to get the weather data. The app displays the current weather, as well as the weather forecast for the next 5 days. The app also displays icons for the different weather conditions, such as sunny, cloudy, rainy, etc. The app is written in C# and uses Windows Forms for the user interface.

## Installation
Just download the project and extract the files. Open the 'Forecaster' directory and run the 'Forecaster.exe' file to start the app.

## Configuration
Before running the app, copy `appsettings.example.json` to `appsettings.json` and enter your OpenWeatherMap API key:

1. Copy `appsettings.example.json` to `appsettings.json`
2. Edit `appsettings.json` and replace `YOUR_OPENWEATHERMAP_API_KEY_HERE` with your actual API key

## Using the App
Just enter the name of the city you want to get the weather forecast for and click the 'Get Weather' button. The app will display the current weather, as well as the weather forecast for the next 5 days. With the 'Next' and 'Previous' buttons you can navigate through the days. The app also displays icons for the different weather conditions.

## Getting your OpenWeatherMap API key
1. Go to [OpenWeatherMap](https://openweathermap.org/api)
2. Sign up for a free account
3. Generate an API key
4. Copy the API key to your `appsettings.json` file

## Security
Your `appsettings.json` file is excluded from version control for security. Only share `appsettings.example.json` publicly.