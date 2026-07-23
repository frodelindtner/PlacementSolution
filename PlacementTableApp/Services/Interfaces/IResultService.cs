using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Domain.Models;

namespace PlacementTableApp.Services.Interfaces
{
    public interface IResultService
    {
        Task<IEnumerable<ResultView>> GetAllAsync();
        Task CreateAsync(ResultView view);

        public Task CreateAsync(ResultEnty enty);
        public Task<ResultEnty?> GetById(int id);
        public Task<ResultEnty?> GetByTeamId(int teamId);
        public Task UpdateResultAsync(ResultView result);
    }
}
