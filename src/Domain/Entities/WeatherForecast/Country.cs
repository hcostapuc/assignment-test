namespace Assignment.Domain.Entities.WeatherForecast;
public class Country : BaseAuditableEntity
{
    public required string Name { get; set; }
    public IList<City> CityCollection { get; private set; } = [];
}
