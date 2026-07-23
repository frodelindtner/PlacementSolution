using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Domain.Models;

namespace PlacementTableApp.Helpers.Mappers
{
    public class EntyModel
    {
        public static ResultEnty ConvertResult(ResultView resultView)
        {
            _ = int.TryParse(resultView.TeamId, out int teamId);
            var rValue = new ResultEnty()
            {
                Id = resultView.Id,
                Losses = resultView.Losses,
                TeamId = teamId,
                Wins = resultView.Wins
            };
            return rValue;
        }

        public static TeamEnty ConvertTeam(TeamView teamView)
        {
            var rValue = new TeamEnty()
            {
                Id = teamView.Id,
                City = teamView.City,
                Division = teamView.Division,
                League = teamView.League,
                Name = teamView.Name,
                Season = teamView.Season
            };
            return rValue;
        }
    }
}
