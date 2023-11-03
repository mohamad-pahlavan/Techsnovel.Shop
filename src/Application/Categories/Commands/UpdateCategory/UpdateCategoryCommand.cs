using MediatR;
using Techsnovel.Application.Common.Exceptions;
using Techsnovel.Application.Common.Interfaces;
using Techsnovel.Domain.Entities;

namespace Techsnovel.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        entity.Name = request.Title;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
