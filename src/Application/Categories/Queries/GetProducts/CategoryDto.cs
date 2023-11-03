using Techsnovel.Application.Common.Mappings;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Application.Categories.Queries.GetProducts;

public class CategoryDto : IMapFrom<Category>
{
    public CategoryDto()
    {
        Products = Array.Empty<ProductDto>();
    }

    public int Id { get; init; }

    public string? Name { get; init; }


    public IReadOnlyCollection<ProductDto> Products { get; init; }
}
