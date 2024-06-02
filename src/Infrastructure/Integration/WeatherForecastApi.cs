using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Application.Common.Interfaces;

namespace Assignment.Infrastructure.Integration;
public class WeatherForecastApi : IWeatherForecastApi
{
    public int GetTemperature(string cityName, DateTime time) =>
        Random.Shared.Next(100);
}
