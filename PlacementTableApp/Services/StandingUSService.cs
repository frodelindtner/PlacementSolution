using PlacementTableApp.Helpers.Mappers;
using PlacementTableApp.Models.DTOs.Input;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;
using System.Text.Json;

namespace PlacementTableApp.Services
{
    public class StandingUSService : IStandingUSService
    {
        public StandingUSService()
        {

        }

        public async Task<List<StandingView>> GetStandingsAsync(string league = null, string division = null)
        {
            var json = await ReadJsonFileAsync();

            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };
            var options = jsonSerializerOptions;

            // Deserialize into an intermediate type that matches expected JSON shape
            var items = JsonSerializer.Deserialize<List<StandingSportData>>(json, options) ?? [];

            // Map to domain DTO Standing
            var result = items.Select(i => SportData.ConvertStandingSportData(i));

            var fResult = result.Where(s => (league == null || s.League.Equals(league, StringComparison.OrdinalIgnoreCase)) &&
                                      (division == null || s.Division.Equals(division, StringComparison.OrdinalIgnoreCase)));

            return [.. fResult];
        }

        private static async Task<string> ReadJsonFileAsync()
        {
            // Expected relative path: tmp-data/data-file-2026
            var relativePath = Path.Combine("tmp-data", "data-file-2026.json");

            // Resolve to absolute path relative to current working directory
            var fullPath = Path.GetFullPath(relativePath);

            if (!File.Exists(fullPath))
            {
                return "[]";
            }

            var json = await File.ReadAllTextAsync(fullPath);
            return json;
        }
    }
}
