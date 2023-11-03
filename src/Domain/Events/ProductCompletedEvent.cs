using Techsnovel.Domain.Common;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Domain.Events;

public class ProductCompletedEvent : BaseEvent
{
    public ProductCompletedEvent(Product item)
    {
        Item = item;
    }

    public Product Item { get; }
}
