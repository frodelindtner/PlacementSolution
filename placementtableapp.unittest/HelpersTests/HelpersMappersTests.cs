using PlacementTableApp.Helpers.Mappers;
using PlacementTableApp.Models.DTOs.Input;
using PlacementTableApp.Models.DTOs.Output;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Domain.Models;
using Xunit;

namespace placementtableapp.unittest.HelpersTests
{
    public class HelpersMappersTests
    {
        [Fact]
        public void Output_ConvertStanding_Maps_Fields()
        {
            var view = new StandingView("2023", "Regular", 11, "CityX", "NameX", "LeagueX", "DivX", 9, 2, 1);

            var dto = Output.ConvertStanding(view);

            Assert.Equal("CityX", dto.City);
            Assert.Equal("DivX", dto.Division);
            Assert.Equal("LeagueX", dto.League);
            Assert.Equal(9, dto.Wins);
            Assert.Equal(2, dto.Losses);
            Assert.Equal("NameX", dto.Name);
            Assert.Equal(1, dto.NightWins);
            Assert.Equal("2023", dto.Season);
            Assert.Equal("Regular", dto.SeasonType);
            Assert.Equal(11, dto.TeamId);
        }

        [Fact]
        public void Standings_ToJson_Includes_Properties()
        {
            var dto = new Standings
            {
                Season = "S",
                SeasonType = "T",
                TeamId = 5,
                City = "C",
                Name = "N",
                League = "L",
                Division = "D",
                Wins = 1,
                Losses = 2,
                NightWins = 3
            };

            var json = dto.ToJson();

            Assert.Contains("\"season\": \"S\"", json);
            Assert.Contains("\"teamId\": 5", json);
            Assert.Contains("\"wins\": 1", json);
            Assert.Contains("\"nightWins\": 3", json);
        }

        [Fact]
        public void SportData_ConvertStandingSportData_Maps_To_StandingView()
        {
            var input = new StandingSportData
            {
                Season = 2024,
                SeasonType = 1,
                TeamId = 22,
                City = "CT",
                Name = "NM",
                League = "LG",
                Division = "DV",
                Wins = 7,
                Losses = 4,
                NightWins = 0
            };

            var view = SportData.ConvertStandingSportData(input);

            Assert.Equal("2024", view.Season);
            Assert.Equal("1", view.SeasonType);
            Assert.Equal(22, view.TeamId);
            Assert.Equal("CT", view.City);
            Assert.Equal("NM", view.Name);
            Assert.Equal("LG", view.League);
            Assert.Equal("DV", view.Division);
            Assert.Equal(7, view.Wins);
            Assert.Equal(4, view.Losses);
            Assert.Equal(0, view.NightWins);
        }

        [Fact]
        public void ViewModel_ConvertResult_And_EntyModel_ConvertResult_Roundtrip()
        {
            var enty = new ResultEnty { Id = 3, TeamId = 12, Wins = 8, Losses = 6 };

            var view = ViewModel.ConvertResult(enty);

            Assert.Equal(3, view.Id);
            Assert.Equal("12", view.TeamId);
            Assert.Equal(8, view.Wins);
            Assert.Equal(6, view.Losses);

            var back = EntyModel.ConvertResult(view);

            Assert.Equal(3, back.Id);
            Assert.Equal(12, back.TeamId);
            Assert.Equal(8, back.Wins);
            Assert.Equal(6, back.Losses);
        }

        [Fact]
        public void ViewModel_ConvertTeam_And_EntyModel_ConvertTeam_Roundtrip()
        {
            var enty = new TeamEnty { Id = 4, City = "Cty", Division = "Div", League = "L", Name = "Nm", Season = "2022" };

            var view = ViewModel.ConvertTeam(enty);

            Assert.Equal(4, view.Id);
            Assert.Equal("Cty", view.City);
            Assert.Equal("Div", view.Division);
            Assert.Equal("L", view.League);
            Assert.Equal("Nm", view.Name);
            Assert.Equal("2022", view.Season);

            var back = EntyModel.ConvertTeam(view);

            Assert.Equal(4, back.Id);
            Assert.Equal("Cty", back.City);
            Assert.Equal("Div", back.Division);
            Assert.Equal("L", back.League);
            Assert.Equal("Nm", back.Name);
            Assert.Equal("2022", back.Season);
        }
    }
}
