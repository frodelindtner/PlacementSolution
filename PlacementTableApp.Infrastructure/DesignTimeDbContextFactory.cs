using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlacementTableApp.Infrastructure
{
    public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StandingDbContext>
    {
        public StandingDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<StandingDbContext>()
                .UseNpgsql("Host=localhost;Database=standingsdb;Username=postgres;Password=postgres")
                .Options;

            return new StandingDbContext(options);
        }
    }
}
