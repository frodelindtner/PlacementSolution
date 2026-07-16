using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PlacementTableApp.Storage
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using var db = new BloggingContext();

            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");

            // Create repositories and services
            var teamRepository = new Repositories.Repository<Team>(db);
            var resultRepository = new Repositories.Repository<Result>(db);

            var teamService = new Services.TeamService(teamRepository);
            var resultService = new Services.ResultService(resultRepository);

            // Create
            var created = await resultService.CreateAsync(new Result { TeamId = 1, Wins = 10, Losses = 5 });
            Console.WriteLine($"Created result id: {created.Id}");

            // Read
            Console.WriteLine("Querying for results");
            var all = await resultService.GetAllAsync();
            var count = all?.Count() ?? 0;
            Console.WriteLine($"Results count: {count}");

            // Update
            Console.WriteLine("Updating the result");
            created.Wins = 15;
            created.Losses = 0;
            await resultService.UpdateAsync(created);

            // Delete
            Console.WriteLine("Delete the result");
            await resultService.DeleteAsync(created.Id);
        }
    }
}
