using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Domain.Models;
using PlacementTableApp.Repositories.Models;

namespace PlacementTableApp.Infrastructure
{
    public interface IStandingDbContext
    {
        public DbSet<ResultEnty> Result { get; set; }
        public DbSet<TeamEnty> Team { get; set; }
    }
}