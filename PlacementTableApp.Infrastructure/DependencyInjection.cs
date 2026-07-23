using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PlacementTableApp.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string pgConn)
        {
            services.AddDbContext<StandingDbContext>(options => options.UseNpgsql(pgConn));
            services.AddScoped<IStandingDbContext>(sp => sp.GetRequiredService<StandingDbContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }

}