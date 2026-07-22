using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Domain.Models;

namespace PlacementTableApp.Domain.Storage
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
    }
}
