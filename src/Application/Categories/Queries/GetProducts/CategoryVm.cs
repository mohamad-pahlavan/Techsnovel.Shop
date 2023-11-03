namespace Techsnovel.Application.Categories.Queries.GetProducts;

public class CategoryVm
{
    public IReadOnlyCollection<CategoryDto> Categories { get; init; } = Array.Empty<CategoryDto>();
}
