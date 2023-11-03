using Techsnovel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Techsnovel.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }

    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
