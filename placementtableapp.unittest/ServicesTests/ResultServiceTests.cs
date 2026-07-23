using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using PlacementTableApp.Domain.Models;
using PlacementTableApp.Helpers.Mappers;
using PlacementTableApp.Infrastructure;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services;
using Xunit;

namespace PlacementTableApp.unittest.ServicesTests
{
    public class ResultServiceTests
    {
        [Fact]
        public async Task GetAllAsync_Returns_ResultViews()
        {
            var seed = new List<ResultEnty>
            {
                new ResultEnty { Id = 1, TeamId = 2, Wins = 10, Losses = 3 }
            };

            var repoMock = new Mock<IRepository<ResultEnty>>();
            repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync((IReadOnlyList<ResultEnty>)seed);

            var service = new ResultService(repoMock.Object);

            var result = await service.GetAllAsync();

            var list = result.ToList();
            Assert.Single(list);
            Assert.Equal(1, list[0].Id);
            Assert.Equal("2", list[0].TeamId);
            Assert.Equal(10, list[0].Wins);
            Assert.Equal(3, list[0].Losses);
        }

        [Fact]
        public async Task GetByTeamId_Returns_Entity()
        {
            var seed = new List<ResultEnty>
            {
                new ResultEnty { Id = 1, TeamId = 5, Wins = 2, Losses = 4 },
                new ResultEnty { Id = 2, TeamId = 6, Wins = 3, Losses = 3 }
            };

            var repoMock = new Mock<IRepository<ResultEnty>>();
            repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync((IReadOnlyList<ResultEnty>)seed);

            var service = new ResultService(repoMock.Object);

            var item = await service.GetByTeamId(6);

            Assert.NotNull(item);
            Assert.Equal(2, item!.Id);
            Assert.Equal(6, item.TeamId);
        }

        [Fact]
        public async Task CreateAsync_With_ResultView_Calls_AddAsync()
        {
            var repoMock = new Mock<IRepository<ResultEnty>>();

            ResultEnty? captured = null;
            repoMock.Setup(r => r.AddAsync(It.IsAny<ResultEnty>()))
                .ReturnsAsync((ResultEnty e) => { e.Id = 7; captured = e; return e; });

            var service = new ResultService(repoMock.Object);

            var view = new ResultView { Id = 0, TeamId = "8", Wins = 12, Losses = 1 };

            await service.CreateAsync(view);

            repoMock.Verify(r => r.AddAsync(It.IsAny<ResultEnty>()), Times.Once);
            Assert.NotNull(captured);
            Assert.Equal(8, captured!.TeamId);
            Assert.Equal(12, captured.Wins);
            Assert.Equal(1, captured.Losses);
        }

        [Fact]
        public async Task UpdateResultAsync_Calls_UpdateAsync()
        {
            var repoMock = new Mock<IRepository<ResultEnty>>();

            ResultEnty? captured = null;
            repoMock.Setup(r => r.UpdateAsync(It.IsAny<ResultEnty>()))
                .Returns((ResultEnty e) => { captured = e; return Task.CompletedTask; });

            var service = new ResultService(repoMock.Object);

            var view = new ResultView { Id = 3, TeamId = "3", Wins = 7, Losses = 5 };

            await service.UpdateResultAsync(view);

            repoMock.Verify(r => r.UpdateAsync(It.IsAny<ResultEnty>()), Times.Once);
            Assert.NotNull(captured);
            Assert.Equal(3, captured!.Id);
            Assert.Equal(3, captured.TeamId);
            Assert.Equal(7, captured.Wins);
        }
    }
}
