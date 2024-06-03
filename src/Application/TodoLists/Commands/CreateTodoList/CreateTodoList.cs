using Assignment.Application.Common.Interfaces;
using Assignment.Domain.Entities.Todo;

namespace Assignment.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand(string Title) : IRequest<int>;

public class CreateTodoListCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateTodoListCommand, int>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoList() { Title = request.Title };

        _context.TodoLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
