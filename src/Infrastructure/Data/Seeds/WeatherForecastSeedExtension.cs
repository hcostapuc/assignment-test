using Assignment.Domain.Entities.WeatherForecast;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.Data.Seeds;
internal static class WeatherForecastSeedExtension
{
    internal static void AddSeed(this DbSet<Country> country) =>
        country.AddRange(new List<Country>()
            {
                new() {
                    Name = "Argentina",
                    CityCollection =
                    {
                        new City{Name = "Buenos Aires"},
                        new City{Name = "Córdoba"},
                        new City{Name = "Rosario"},
                    }
                },
                new() {
                    Name = "Australia",
                    CityCollection =
                    {
                        new City{Name = "Sydney"},
                        new City{Name = "Melbourne"},
                        new City{Name = "Brisbane"},
                    }
                },
                new() {
                    Name = "Austria",
                    CityCollection =
                    {
                        new City{Name = "Vienna"},
                        new City{Name = "Graz"},
                        new City{Name = "Linz"},
                    }
                },
                new() {
                    Name = "Bangladesh",
                    CityCollection =
                    {
                        new City{Name = "Dhaka"},
                        new City{Name = "Chittagong"},
                        new City{Name = "Khulna"},
                    }
                },
                new() {
                    Name = "Belgium",
                    CityCollection =
                    {
                        new City{Name = "Brussels"},
                        new City{Name = "Antwerp"},
                        new City{Name = "Ghent"},
                    }
                },
                new() {
                    Name = "Brazil",
                    CityCollection =
                    {
                        new City{Name = "São Paulo"},
                        new City{Name = "Rio de Janeiro"},
                        new City{Name = "Brasília"},
                    }
                },
                new() {
                    Name = "Bulgaria",
                    CityCollection =
                    {
                        new City{Name = "Sofia"},
                        new City{Name = "Plovdiv"},
                        new City{Name = "Varna"},
                    }
                },
                new() {
                    Name = "Canada",
                    CityCollection =
                    {
                        new City{Name = "Toronto"},
                        new City{Name = "Vancouver"},
                        new City{Name = "Montreal"},
                    }
                },
                new() {
                    Name = "China",
                    CityCollection =
                    {
                        new City{Name = "Beijing"},
                        new City{Name = "Shanghai"},
                        new City{Name = "Guangzhou"},
                    }
                },
                new() {
                    Name = "Czech Republic",
                    CityCollection =
                    {
                        new City{Name = "Prague"},
                        new City{Name = "Brno"},
                        new City{Name = "Ostrava"},
                    }
                },
                new() {
                    Name = "Denmark",
                    CityCollection =
                    {
                        new City{Name = "Copenhagen"},
                        new City{Name = "Aarhus"},
                        new City{Name = "Odense"},
                    }
                },
                new() {
                    Name = "Egypt",
                    CityCollection =
                    {
                        new City{Name = "Cairo"},
                        new City{Name = "Alexandria"},
                        new City{Name = "Giza"},
                    }
                },
                new() {
                    Name = "Finland",
                    CityCollection =
                    {
                        new City{Name = "Helsinki"},
                        new City{Name = "Espoo"},
                        new City{Name = "Tampere"},
                    }
                },
                new() {
                    Name = "France",
                    CityCollection =
                    {
                        new City{Name = "Paris"},
                        new City{Name = "Marseille"},
                        new City{Name = "Lyon"},
                    }
                },
                new() {
                    Name = "Germany",
                    CityCollection =
                    {
                        new City{Name = "Berlin"},
                        new City{Name = "Munich"},
                        new City{Name = "Hamburg"},
                    }
                },
                new() {
                    Name = "Greece",
                    CityCollection =
                    {
                        new City{Name = "Athens"},
                        new City{Name = "Thessaloniki"},
                        new City{Name = "Patras"},
                    }
                },
                new() {
                    Name = "Hungary",
                    CityCollection =
                    {
                        new City{Name = "Budapest"},
                        new City{Name = "Debrecen"},
                        new City{Name = "Szeged"},
                    }
                },
                new() {
                    Name = "India",
                    CityCollection =
                    {
                        new City{Name = "New Delhi"},
                        new City{Name = "Mumbai"},
                        new City{Name = "Bangalore"},
                    }
                },
                new() {
                    Name = "Indonesia",
                    CityCollection =
                    {
                        new City{Name = "Jakarta"},
                        new City{Name = "Surabaya"},
                        new City{Name = "Bandung"},
                    }
                },
                new() {
                    Name = "Iran",
                    CityCollection =
                    {
                        new City{Name = "Tehran"},
                        new City{Name = "Mashhad"},
                        new City{Name = "Isfahan"},
                    }
                },
                new() {
                    Name = "Iraq",
                    CityCollection =
                    {
                        new City{Name = "Baghdad"},
                        new City{Name = "Basra"},
                        new City{Name = "Erbil"},
                    }
                },
                new() {
                    Name = "Ireland",
                    CityCollection =
                    {
                        new City{Name = "Dublin"},
                        new City{Name = "Cork"},
                    }
                },
                new() {
                    Name = "Israel",
                    CityCollection =
                    {
                        new City{Name = "Jerusalem"},
                        new City{Name = "Tel Aviv"},
                        new City{Name = "Haifa"},
                    }
                },
                new() {
                    Name = "Italy",
                    CityCollection =
                    {
                        new City{Name = "Rome"},
                        new City{Name = "Milan"},
                        new City{Name = "Naples"},
                    }
                },
                new() {
                    Name = "Japan",
                    CityCollection =
                    {
                        new City{Name = "Tokyo"},
                        new City{Name = "Osaka"},
                        new City{Name = "Kyoto"},
                    }
                },
                new() {
                    Name = "Malaysia",
                    CityCollection =
                    {
                        new City{Name = "Kuala Lumpur"},
                        new City{Name = "George Town"},
                        new City{Name = "Johor Bahru"},
                    }
                },
                new() {
                    Name = "Mexico",
                    CityCollection =
                    {
                        new City{Name = "Mexico City"},
                        new City{Name = "Guadalajara"},
                        new City{Name = "Monterrey"},
                    }
                },
                new() {
                    Name = "Netherlands",
                    CityCollection =
                    {
                        new City{Name = "Amsterdam"},
                        new City{Name = "Rotterdam"},
                        new City{Name = "The Hague"},
                    }
                },
                new() {
                    Name = "New Zealand",
                    CityCollection =
                    {
                        new City{Name = "Auckland"},
                        new City{Name = "Wellington"},
                        new City{Name = "Christchurch"},
                    }
                },
                new() {
                    Name = "Nigeria",
                    CityCollection =
                    {
                        new City{Name = "Lagos"},
                        new City{Name = "Abuja"},
                        new City{Name = "Kano"},
                    }
                },
                new() {
                    Name = "Norway",
                    CityCollection =
                    {
                        new City{Name = "Oslo"},
                        new City{Name = "Bergen"},
                        new City{Name = "Trondheim"},
                    }
                },
                new() {
                    Name = "Pakistan",
                    CityCollection =
                    {
                        new City{Name = "Karachi"},
                        new City{Name = "Lahore"},
                        new City{Name = "Islamabad"},
                    }
                },
                new() {
                    Name = "Philippines",
                    CityCollection =
                    {
                        new City{Name = "Manila"},
                        new City{Name = "Quezon City"},
                        new City{Name = "Cebu City"},
                    }
                },
                new() {
                    Name = "Poland",
                    CityCollection =
                    {
                        new City{Name = "Warsaw"},
                        new City{Name = "Kraków"},
                        new City{Name = "Wrocław"},
                    }
                },
                new() {
                    Name = "Qatar",
                    CityCollection =
                    {
                        new City{Name = "Doha"},
                        new City{Name = "Al Rayyan"},
                    }
                },
                new() {
                    Name = "Romania",
                    CityCollection =
                    {
                        new City{Name = "Bucharest"},
                        new City{Name = "Cluj-Napoca"},
                        new City{Name = "Timișoara"},
                    }
                },
                new() {
                    Name = "Russia",
                    CityCollection =
                    {
                        new City{Name = "Moscow"},
                        new City{Name = "Saint Petersburg"},
                        new City{Name = "Novosibirsk"},
                    }
                },
                new() {
                    Name = "Saudi Arabia",
                    CityCollection =
                    {
                        new City{Name = "Riyadh"},
                        new City{Name = "Jeddah"},
                        new City{Name = "Mecca"},
                    }
                },
                new() {
                    Name = "South Africa",
                    CityCollection =
                    {
                        new City{Name = "Johannesburg"},
                        new City{Name = "Cape Town"},
                        new City{Name = "Durban"},
                    }
                },
                new() {
                    Name = "South Korea",
                    CityCollection =
                    {
                        new City{Name = "Seoul"},
                        new City{Name = "Busan"},
                        new City{Name = "Incheon"},
                    }
                },
                new() {
                    Name = "Spain",
                    CityCollection =
                    {
                        new City{Name = "Madrid"},
                        new City{Name = "Barcelona"},
                        new City{Name = "Valencia"},
                    }
                },
                new() {
                    Name = "Sweden",
                    CityCollection =
                    {
                        new City{Name = "Stockholm"},
                        new City{Name = "Gothenburg"},
                        new City{Name = "Malmö"},
                    }
                },
                new() {
                    Name = "Switzerland",
                    CityCollection =
                    {
                        new City{Name = "Zurich"},
                        new City{Name = "Geneva"},
                        new City{Name = "Basel"},
                    }
                },
                new() {
                    Name = "Thailand",
                    CityCollection =
                    {
                        new City{Name = "Bangkok"},
                        new City{Name = "Chiang Mai"},
                        new City{Name = "Pattaya"},
                    }
                },
                new() {
                    Name = "Turkey",
                    CityCollection =
                    {
                        new City{Name = "Istanbul"},
                        new City{Name = "Ankara"},
                        new City{Name = "Izmir"},
                    }
                },
                new() {
                    Name = "UAE",
                    CityCollection =
                    {
                        new City{Name = "Dubai"},
                        new City{Name = "Abu Dhabi"},
                        new City{Name = "Sharjah"},
                    }
                },
                new() {
                    Name = "Ukraine",
                    CityCollection =
                    {
                        new City{Name = "Kyiv (Kiev)"},
                        new City{Name = "Kharkiv"},
                        new City{Name = "Odessa"},
                    }
                },
                new() {
                    Name = "United Kingdom",
                    CityCollection =
                    {
                        new City{Name = "London"},
                        new City{Name = "Manchester"},
                        new City{Name = "Birmingham"},
                    }
                },
                new() {
                    Name = "United States",
                    CityCollection =
                    {
                        new City{Name = "New York City"},
                        new City{Name = "Los Angeles"},
                        new City{Name = "Chicago"},
                    }
                },
                new() {
                    Name = "Vietnam",
                    CityCollection =
                    {
                        new City{Name = "Hanoi"},
                        new City{Name = "Ho Chi Minh City"},
                        new City{Name = "Da Nang"},
                    }
                },
            });
}
