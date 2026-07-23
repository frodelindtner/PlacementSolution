using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Domain.Models;

namespace PlacementTableApp.Helpers.Mappers
{
    public class ViewModel
    {
        public static ResultView ConvertResult(ResultEnty resultEnty)
        {
            var rValue = new ResultView
            {
                Wins = resultEnty.Wins,
                Losses = resultEnty.Losses,
                TeamId = resultEnty.TeamId.ToString(),
                Id = resultEnty.Id
            };
            return rValue;
        }

        public static TeamView ConvertTeam(TeamEnty teamEnty)
        {
            var rValue = new TeamView
            {
                Id = teamEnty.Id,
                City = teamEnty.City,
                Division = teamEnty.Division,
                League = teamEnty.League,
                Name = teamEnty.Name,
                Season = teamEnty.Season
            };
            return rValue;
        }
    }
}
