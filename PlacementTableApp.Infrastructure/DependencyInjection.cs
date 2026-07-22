using Microsoft.Extensions.DependencyInjection;

namespace PlacementTableApp.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Hand the Application layer its IApplicationDbContext, backed by the
            // real ApplicationDbContext. Aspire registers the DbContext itself in
            // the API project, so here we only map the interface to the concrete type.
            services.AddScoped<IMoviesDbContext>(sp => sp.GetRequiredService<MoviesDbContext>());
            return services;
        }
    }

}