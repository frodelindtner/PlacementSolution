using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Repositories.Models;

namespace PlacementTableApp.Services.Interfaces
{
    public interface IResultService
    {
        Task<IEnumerable<PlacementTableApp.Models.ViewModels.ResultView>> GetAllAsync();
        Task CreateAsync(PlacementTableApp.Models.ViewModels.ResultView view);

        public Task CreateAsync(ResultEnty enty);
        public Task<ResultEnty> GetById(int id);
        public Task<ResultEnty> GetByTeamId(int teamId);
        public Task UpdateResultAsync(ResultView result);
    }
}
