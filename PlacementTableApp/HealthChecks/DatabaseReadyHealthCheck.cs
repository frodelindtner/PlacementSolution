using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;

namespace PlacementTableApp.HealthChecks
{
    public class DatabaseReadyHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;

        public DatabaseReadyHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var connStr = _configuration.GetConnectionString("standingsdb") ?? _configuration["standingsdb"];

            if (string.IsNullOrWhiteSpace(connStr))
            {
                return HealthCheckResult.Unhealthy("Postgres connection string 'standingsdb' not configured.");
            }

            try
            {
                await using var conn = new NpgsqlConnection(connStr);
                await conn.OpenAsync(cancellationToken);

                // Check whether the 'movie' table exists in public schema
                const string sql = @"
                    SELECT EXISTS (
                        SELECT 1
                        FROM information_schema.tables
                        WHERE table_schema = 'public'
                          AND table_name = 'movie'
                    );";

                await using var cmd = new NpgsqlCommand(sql, conn);
                var result = await cmd.ExecuteScalarAsync(cancellationToken);
                if (result is bool exists && exists)
                {
                    return HealthCheckResult.Healthy("Postgres is reachable and 'movie' table exists.");
                }

                return HealthCheckResult.Unhealthy("'movie' table not found in the Postgres database.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"Postgres check failed: {ex.Message}");
            }
        }
    }
}
