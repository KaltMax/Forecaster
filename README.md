# Forecaster - Weather App for Windows

## Description
This is a simple weather app that displays the weather forecast for a given city. The app uses the OpenWeatherMap API to get the weather data. The app displays the current weather, as well as the weather forecast for the next 5 days. The app also displays icons for the different weather conditions, such as sunny, cloudy, rainy, etc. The app is written in C# and uses Windows Forms for the user interface.

## Installation
1. Download the latest release from the [Releases](https://github.com/KaltMax/forecaster/releases) page.
2. Extract the `Forecaster-latest.zip` file.
3. Navigate to the `Forecaster/` directory and open the `appsettings.json`.
4. Replace `YOUR_OPENWEATHERMAP_API_KEY_HERE` with your actual OpenWeatherMap API key.
5. Run the `Forecaster.exe` file to start the application.

## Using the App
1. Enter the name of the city you want to get the weather forecast for.
2. Click the 'Search' button.
3. View the current weather and the 5-day forecast.
4. Use the horizontal scrollbar to navigate through the forecast days.

## Security
Your `appsettings.json` file is excluded from version control for security. Only share `appsettings.example.json` publicly.

## Build and Release
The release package includes:
- All build files for `net9.0-windows` in the `Forecaster/` directory.
- The `README.md` file for reference.

To build the project yourself:
1. Clone the repository.
2. Copy `appsettings.example.json` to `appsettings.json` in the `Forecaster/` directory.
3. Open `appsettings.json` and replace `YOUR_OPENWEATHERMAP_API_KEY_HERE` with your actual API key.
4. Run the `dotnet build` command.