using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Storage.Models;

namespace PlacementTableApp.Storage
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
