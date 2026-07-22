using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Domain.Models;

namespace PlacementTableApp.Infrastructure
{
    public sealed class MoviesDbContext(DbContextOptions<MoviesDbContext> options)
        : DbContext(options), IMoviesDbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Picks up every IEntityTypeConfiguration in this assembly automatically.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}