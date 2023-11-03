using Techsnovel.Domain.Common;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Domain.Events;

public class ProductCreatedEvent : BaseEvent
{
    public ProductCreatedEvent(Product item)
    {
        Item = item;
    }

    public Product Item { get; }
}
