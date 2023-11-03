using MediatR;
using Techsnovel.Application.Common.Interfaces;

namespace Techsnovel.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand : IRequest<int>
{
    public string? Name { get; init; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Category();

        entity.Name = request.Name;

        _context.Categories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
