using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Security;

namespace Assignment.Application.Country.Queries.GetCountryCollection;

[Authorize]
public record GetCountryCollectionQuery : IRequest<IList<CountryDto>>;

public class GetCountryCollectionQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetCountryCollectionQuery, IList<CountryDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IList<CountryDto>> Handle(GetCountryCollectionQuery request, CancellationToken cancellationToken) =>
         await _context.Country
                .AsNoTracking()
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken);
}
