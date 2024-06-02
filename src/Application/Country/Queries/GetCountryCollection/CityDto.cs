using Assignment.Domain.Entities.WeatherForecast;

namespace Assignment.Application.Country.Queries.GetCountryCollection;

public class CityDto
{
    public int Id { get; init; }
    public int CountryId { get; set; }
    public required string Name { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<City, CityDto>();
        }
    }
}
