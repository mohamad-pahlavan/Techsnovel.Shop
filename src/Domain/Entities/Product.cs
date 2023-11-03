using Techsnovel.Domain.Common;

namespace Techsnovel.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public Category Category { get; set; } = null!;
}
