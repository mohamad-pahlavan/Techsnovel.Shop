using MediatR;
using Techsnovel.Application.Common.Interfaces;
using Techsnovel.Domain.Entities;
using Techsnovel.Domain.Events;

namespace Techsnovel.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public int CategoryId { get; init; }

    public string? Name { get; init; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product()
        {
            CategoryId = request.CategoryId,
            Name = request.Name
        };

        entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
