using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Infrastructure.Models;

namespace PlacementTableApp.Infrastructure
{

    // This interface is how the Application layer talks to the database without
    // depending on the Infrastructure project. It exposes the DbSet directly, so
    // services get the full power of EF Core and LINQ - no repository in between.
    public interface IApplicationDbContext
    {
        DbSet<Movie> Movies { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}