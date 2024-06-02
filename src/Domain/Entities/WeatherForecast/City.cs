namespace Assignment.Domain.Entities.WeatherForecast;
public class City : BaseAuditableEntity
{
    public int CountryId { get; set; }
    public required string Name { get; set; }
}
