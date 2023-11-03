using Techsnovel.Application.Common.Mappings;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Application.Products.Queries.GetProductWithPagination;

public class ProductBriefDto : IMapFrom<Product>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
