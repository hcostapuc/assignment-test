
namespace Assignment.Application.Country.Queries.GetCountryCollection;

public class CountryDto
{
    public CountryDto()
    {
        CityCollection = Array.Empty<CityDto>();
    }

    public int Id { get; init; }
    public required string Name { get; set; }
    public IList<CityDto> CityCollection { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Assignment.Domain.Entities.WeatherForecast.Country, CountryDto>();
        }
    }
}
