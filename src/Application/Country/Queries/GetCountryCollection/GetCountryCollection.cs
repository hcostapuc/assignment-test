using Assignment.Application.Common.Interfaces;
using Assignment.Application.Common.Security;

namespace Assignment.Application.Country.Queries.GetCountryCollection;

[Authorize]
public record GetCountryCollectionQuery : IRequest<IList<CountryDto>>;

public class GetCountryCollectionQueryHandler : IRequestHandler<GetCountryCollectionQuery, IList<CountryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCountryCollectionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<CountryDto>> Handle(GetCountryCollectionQuery request, CancellationToken cancellationToken)
    {
        return await _context.Country
                .AsNoTracking()
                .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken);
    }
}
