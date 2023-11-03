using MediatR;
using Techsnovel.Application.Common.Exceptions;
using Techsnovel.Application.Common.Interfaces;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
