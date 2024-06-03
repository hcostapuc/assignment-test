using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities.Todo;
using Assignment.Domain.Enums;
using Assignment.Domain.Events;

namespace Assignment.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public required string Title { get; init; }
    public string? Note { get; init; }
    public PriorityLevel Priority { get; set; }
}

public class CreateTodoItemCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTodoItemCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Priority = request.Priority,
            Note = request.Note,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        await _context.TodoItems.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
