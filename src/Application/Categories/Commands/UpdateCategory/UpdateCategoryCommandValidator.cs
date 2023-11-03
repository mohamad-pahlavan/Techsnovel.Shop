using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Techsnovel.Application.Common.Interfaces;

namespace Techsnovel.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(UpdateCategoryCommand model, string name, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(c => c.Id != model.Id)
            .AllAsync(c => c.Name != name, cancellationToken);
    }
}
