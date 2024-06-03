using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Security;

namespace Assignment.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IRequest<IList<TodoListDto>>;

public class GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetTodosQuery, IList<TodoListDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<TodoListDto>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
                .AsNoTracking()
                .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken);
    }
}
