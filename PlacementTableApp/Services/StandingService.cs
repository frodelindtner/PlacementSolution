using PlacementTableApp.Helpers.Mappers;
using PlacementTableApp.Models.DTOs.Input;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;
using System.Text.Json;

namespace PlacementTableApp.Services
{
    public class StandingService : IStandingService
    {
        private ITeamService _teamService;
        private IResultService _resultService;

        public StandingService(ITeamService teamService, IResultService resultService)
        {
            _teamService = teamService;
            _resultService = resultService;
        }

        public async Task<List<StandingView>> GetStandingLocalAsync(string league = null, string division = null)
        {
            var standings = new List<StandingView>();
            var teams = _teamService.GetTeamsAsync().Result;
            foreach (var team in teams) {
                var result = _resultService.GetByTeamId(team.Id).Result;
                if (result != null)
                {
                    var item = new StandingView(team.Season ?? string.Empty, "N/A", team.Id, team.City ?? string.Empty,
                        team.Name ?? string.Empty, team.League ?? string.Empty, team.Division ?? string.Empty,
                        result.Wins, result.Losses, 0);
                    
                    standings.Add(item);
                }
            }
            var orderStandings = standings.OrderByDescending(x => x.Wins).ThenBy(x => x.Losses);
            return [.. orderStandings];
        }


        public async Task<List<StandingView>> GetStandingsUSAsync(string league = null, string division = null)
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
