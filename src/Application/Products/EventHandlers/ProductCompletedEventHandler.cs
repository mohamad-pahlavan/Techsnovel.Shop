using MediatR;
using Microsoft.Extensions.Logging;
using Techsnovel.Domain.Events;

namespace Techsnovel.Application.Products.EventHandlers;

public class ProductCompletedEventHandler : INotificationHandler<ProductCompletedEvent>
{
    private readonly ILogger<ProductCompletedEventHandler> _logger;

    public ProductCompletedEventHandler(ILogger<ProductCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sample Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
