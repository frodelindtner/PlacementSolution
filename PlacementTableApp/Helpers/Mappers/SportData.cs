using Microsoft.AspNetCore.Components.Forms;
using PlacementTableApp.Models.DTOs.Input;
using PlacementTableApp.Models.ViewModels;

namespace PlacementTableApp.Helpers.Mappers
{
    public class SportData
    {
        public static StandingView ConvertStandingSportData(StandingSportData standingSportData)
        {
            return new StandingView(
                standingSportData.Season.ToString() ?? string.Empty,
                standingSportData.SeasonType.ToString() ?? string.Empty,
                standingSportData.TeamId,
                standingSportData.City ?? string.Empty,
                standingSportData.Name ?? string.Empty,
                standingSportData.League ?? string.Empty,
                standingSportData.Division ?? string.Empty,
                standingSportData.Wins,
                standingSportData.Losses,
                standingSportData.NightWins ?? 0
            );
        }

    }
}
