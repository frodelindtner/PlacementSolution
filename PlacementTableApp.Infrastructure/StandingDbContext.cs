using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Domain.Models;

namespace PlacementTableApp.Infrastructure
{
    public sealed class StandingDbContext(DbContextOptions<StandingDbContext> options)
        : DbContext(options), IStandingDbContext
    {
        public DbSet<ResultEnty> Result { get; set; }
        public DbSet<TeamEnty> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StandingDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}