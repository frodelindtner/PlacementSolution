using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Domain.Models;

namespace PlacementTableApp.Infrastructure
{
    public interface IStandingDbContext
    {
        public DbSet<ResultEnty> Result { get; set; }
        public DbSet<TeamEnty> Team { get; set; }
    }
}