using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using PlacementTableApp.Domain.Models;
using PlacementTableApp.Services;
using PlacementTableApp.Infrastructure;
using PlacementTableApp.Models.ViewModels;
using Xunit;

namespace PlacementTableApp.unittest.ServicesTests
{
    public class TeamServiceTests
    {
        [Fact]
        public async Task GetTeamsAsync_Returns_TeamViews()
        {
            var seed = new List<TeamEnty>
            {
                new TeamEnty { Id = 1, Name = "TeamA", League = "L1", Season = "2023", City = "C", Division = "D" }
            };

            var teamRepoMock = new Mock<IRepository<TeamEnty>>();
            teamRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(seed);

            var resultRepoMock = new Mock<IRepository<ResultEnty>>();

            var service = new TeamService(teamRepoMock.Object, resultRepoMock.Object);

            var list = await service.GetTeamsAsync();

            Assert.Single(list);
            Assert.Equal("TeamA", list[0].Name);
            Assert.Equal("L1", list[0].League);
        }

        [Fact]
        public void CreateFilers_Returns_DistinctLeagues()
        {
            var seed = new List<TeamEnty>
            {
                new TeamEnty { Id = 1, League = "L1" },
                new TeamEnty { Id = 2, League = "L1" },
                new TeamEnty { Id = 3, League = "L2" }
            };

            var teamRepoMock = new Mock<IRepository<TeamEnty>>();
            teamRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(seed);

            var resultRepoMock = new Mock<IRepository<ResultEnty>>();

            var service = new TeamService(teamRepoMock.Object, resultRepoMock.Object);

            var filters = service.CreateFilers();

            Assert.Contains("L1", filters);
            Assert.Contains("L2", filters);
            Assert.Equal(2, filters.Count);
        }

        [Fact]
        public async Task AddTeamAsync_Adds_Team_And_Result()
        {
            var teamRepoMock = new Mock<IRepository<TeamEnty>>();
            var resultRepoMock = new Mock<IRepository<ResultEnty>>();

            TeamEnty? capturedTeam = null;
            ResultEnty? capturedResult = null;

            teamRepoMock
                .Setup(r => r.AddAsync(It.IsAny<TeamEnty>()))
                .ReturnsAsync((TeamEnty t) =>
                {
                    t.Id = 1;
                    capturedTeam = t;
                    return t;
                });

            resultRepoMock
                .Setup(r => r.AddAsync(It.IsAny<ResultEnty>()))
                .ReturnsAsync((ResultEnty res) =>
                {
                    res.Id = 1;
                    capturedResult = res;
                    return res;
                });

            var service = new TeamService(teamRepoMock.Object, resultRepoMock.Object);

            var teamView = new TeamView { Name = "NewTeam", League = "L3", City = "X", Division = "Div", Season = "2024" };

            var outer = await service.AddTeamAsync(teamView);
            await outer;

            teamRepoMock.Verify(r => r.AddAsync(It.IsAny<TeamEnty>()), Times.Once);
            resultRepoMock.Verify(r => r.AddAsync(It.IsAny<ResultEnty>()), Times.Once);

            Assert.NotNull(capturedTeam);
            Assert.NotNull(capturedResult);
            Assert.Equal("NewTeam", capturedTeam!.Name);
            Assert.Equal(capturedTeam.Id, capturedResult!.TeamId);
        }
    }
}
