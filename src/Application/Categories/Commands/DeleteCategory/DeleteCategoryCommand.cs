using MediatR;
using Microsoft.EntityFrameworkCore;
using Techsnovel.Application.Common.Exceptions;
using Techsnovel.Application.Common.Interfaces;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(int Id) : IRequest;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .Where(c => c.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        _context.Categories.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
