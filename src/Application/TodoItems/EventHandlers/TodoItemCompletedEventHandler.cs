using Assignment.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Assignment.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger) : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger = logger;

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Assignment Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
