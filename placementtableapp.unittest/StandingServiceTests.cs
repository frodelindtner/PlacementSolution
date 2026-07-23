using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services;
using PlacementTableApp.Services.Interfaces;
using PlacementTableApp.Domain.Models;
using Xunit;

namespace placementtableapp.unittest
{
    public class StandingServiceTests
    {
        [Fact]
        public async Task GetStandingLocalAsync_Returns_StandingViews()
        {
            var teams = new List<TeamView>
            {
                new TeamView { Id = 1, Name = "TeamA", League = "L1", Season = "2023", City = "C", Division = "D" }
            };

            var result = new ResultEnty { Id = 1, TeamId = 1, Wins = 5, Losses = 2 };

            var teamServiceMock = new Mock<ITeamService>();
            teamServiceMock.Setup(s => s.GetTeamsAsync()).ReturnsAsync(teams);

            var resultServiceMock = new Mock<IResultService>();
            resultServiceMock.Setup(r => r.GetByTeamId(1)).ReturnsAsync(result);

            var service = new StandingService(teamServiceMock.Object, resultServiceMock.Object);

            var list = await service.GetStandingLocalAsync();

            Assert.Single(list);
            Assert.Equal("TeamA", list[0].Name);
            Assert.Equal(5, list[0].Wins);
            Assert.Equal(2, list[0].Losses);
        }
    }
}
