using Microsoft.Extensions.DependencyInjection;

namespace PlacementTableApp.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IStandingDbContext>(sp => sp.GetRequiredService<StandingDbContext>());
            return services;
        }
    }

}