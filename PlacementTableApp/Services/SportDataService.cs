using PlacementTableApp.Helpers.Mappers;
using PlacementTableApp.Models.DTOs.Input;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlacementTableApp.Services
{
    public class SportDataService : ISportDataService
    {
        public SportDataService() { }

        public async Task<List<StandingView>> GetStandingsUSAsync(string league = null, string division = null)
        {
            var items = await ReadJsonFileAsync();
            //var items = await ReadApiJsonAsync();

            // Map to domain DTO Standing
            var result = items.Select(i => SportData.ConvertStandingSportData(i));

            var fResult = result.Where(s => (league == null || s.League.Equals(league, StringComparison.OrdinalIgnoreCase)) &&
                                      (division == null || s.Division.Equals(division, StringComparison.OrdinalIgnoreCase)));

            return [.. fResult];
        }
        private static async Task<List<StandingSportData>> ReadJsonFileAsync()
        {
            // Expected relative path: tmp-data/data-file-2026
            var relativePath = Path.Combine("tmp-data", "data-file-2026.json");

            // Resolve to absolute path relative to current working directory
            var fullPath = Path.GetFullPath(relativePath);

            if (!File.Exists(fullPath))
            {
                throw new Exception("file path not match");
            }

            var json = await File.ReadAllTextAsync(fullPath);

            JsonSerializerOptions jsonSerializerOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };
            var options = jsonSerializerOptions;

            // Deserialize into an intermediate type that matches expected JSON shape
            var items = JsonSerializer.Deserialize<List<StandingSportData>>(json, options) ?? [];

            return items;
        }

        private static async Task<List<StandingSportData>> ReadApiJsonAsync()
        {
            List<StandingSportData> items = new List<StandingSportData>();
            var key = "{api_key}";

            var url = $"https://api.sportsdata.io/v3/mlb/scores/json/Standings/2026?key={key}";

            HttpClient client = new();

            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                JsonSerializerOptions jsonSerializerOptions = new()
                {
                    PropertyNameCaseInsensitive = true
                };
                var options = jsonSerializerOptions;

                items = JsonSerializer.Deserialize<List<StandingSportData>>(jsonString, options) ?? [];

            }
            return items;
        }
    }
}