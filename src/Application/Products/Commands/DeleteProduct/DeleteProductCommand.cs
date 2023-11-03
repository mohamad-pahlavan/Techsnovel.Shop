using MediatR;
using Techsnovel.Application.Common.Exceptions;
using Techsnovel.Application.Common.Interfaces;
using Techsnovel.Domain.Entities;
using Techsnovel.Domain.Events;

namespace Techsnovel.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        _context.Products.Remove(entity);

        entity.AddDomainEvent(new ProductDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
