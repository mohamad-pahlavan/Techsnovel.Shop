using Techsnovel.Domain.Common;

namespace Techsnovel.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string? Name { get; set; }

    public IList<Product> Products { get; private set; } = new List<Product>();
}
