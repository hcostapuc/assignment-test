using Assignment.Domain.Entities.Todo;
using Assignment.Domain.Entities.WeatherForecast;

namespace Assignment.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Assignment.Domain.Entities.WeatherForecast.Country> Country { get; }
    DbSet<City> City { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
