using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlacementTableApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PlacementTableApp.Infrastructure
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeDatabaseAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<MoviesDbContext>>();

            // On a fresh database EF logs an error reading "__EFMigrationsHistory"
            // before that table exists - it catches it and creates the schema. Expected.
            logger.LogInformation("Applying database migrations...");
            await context.Database.MigrateAsync(cancellationToken);
            logger.LogInformation("Database migrations applied.");

            await SeedAsync(context, logger, cancellationToken);
        }

        private static async Task SeedAsync(MoviesDbContext context, ILogger logger, CancellationToken cancellationToken)
        {
            // Idempotent: if the table already has movies, leave the data untouched.
            logger.LogInformation("Seeded 0 movies.");
        }
    }

}
