using Techsnovel.Application.Common.Mappings;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<Category>, IMapFrom<Product>
{
    public int Id { get; init; }

    public string? Name { get; init; }
}
