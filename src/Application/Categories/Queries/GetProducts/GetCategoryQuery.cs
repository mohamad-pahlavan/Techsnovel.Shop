using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Techsnovel.Application.Common.Interfaces;
using Techsnovel.Application.Common.Security;

namespace Techsnovel.Application.Categories.Queries.GetProducts;

[Authorize]
public record GetCategoryQuery : IRequest<CategoryVm>;

public class GetProductsQueryHandler : IRequestHandler<GetCategoryQuery, CategoryVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryVm> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        return new CategoryVm
        {
            Categories = await _context.Categories
                .AsNoTracking()
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken)
        };
    }
}
