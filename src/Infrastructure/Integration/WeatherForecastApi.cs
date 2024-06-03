using Assignment.Application.Common.Interfaces;

namespace Assignment.Infrastructure.Integration;
public class WeatherForecastApi : IWeatherForecastApi
{
    public int GetTemperature(string cityName, DateTime time) =>
        Random.Shared.Next(100);
}
