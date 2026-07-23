using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Models.DTOs.Output;

namespace PlacementTableApp.Helpers.Mappers
{
    public class Output
    {
        public static Standings ConvertStanding(StandingView view)
        {
            var rValue = new Standings
            {
                City = view.City,
                Division = view.Division,
                League = view.League,
                Losses = view.Losses,
                Name = view.Name,
                NightWins = view.NightWins,
                Season = view.Season,
                SeasonType = view.SeasonType,
                TeamId = view.TeamId,
                Wins = view.Wins                
            };
            return rValue;
        }
    }
}
