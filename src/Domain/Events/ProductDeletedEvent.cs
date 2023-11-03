using Techsnovel.Domain.Common;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Domain.Events;

public class ProductDeletedEvent : BaseEvent
{
    public ProductDeletedEvent(Product item)
    {
        Item = item;
    }

    public Product Item { get; }
}
