using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlacementTableApp.Infrastructure
{
    public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MoviesDbContext>
    {
        public MoviesDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
                .UseNpgsql("Host=localhost;Database=standingsdb;Username=postgres;Password=postgres")
                .Options;

            return new MoviesDbContext(options);
        }
    }
}
