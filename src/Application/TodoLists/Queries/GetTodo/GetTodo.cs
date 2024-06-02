using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Security;
using Assignment.Application.TodoLists.Queries.GetTodos;

namespace Assignment.Application.TodoLists.Queries.GetTodo;

[Authorize]
public record GetTodoQuery(int ListId) : IRequest<TodoListDto>;

public class GetTodoQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTodoQuery, TodoListDto>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<TodoListDto> Handle(GetTodoQuery request, CancellationToken cancellationToken) =>
        await _context.TodoLists
                .AsNoTracking()
                .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                .SingleAsync(x => x.Id == request.ListId, cancellationToken);
}
