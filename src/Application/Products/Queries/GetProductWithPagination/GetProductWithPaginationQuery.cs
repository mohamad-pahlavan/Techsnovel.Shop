using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Techsnovel.Application.Common.Interfaces;
using Techsnovel.Application.Common.Mappings;
using Techsnovel.Application.Common.Models;

namespace Techsnovel.Application.Products.Queries.GetProductWithPagination;

public record GetProductWithPaginationQuery : IRequest<PaginatedList<ProductBriefDto>>
{
    public int CategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductWithPaginationQueryHandler : IRequestHandler<GetProductWithPaginationQuery, PaginatedList<ProductBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductBriefDto>> Handle(GetProductWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Where(x => x.CategoryId == request.CategoryId)
            .OrderBy(x => x.Name)
            .ProjectTo<ProductBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
