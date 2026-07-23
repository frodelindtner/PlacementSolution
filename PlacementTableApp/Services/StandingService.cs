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

    }
}
