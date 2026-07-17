using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Repositories.Interfaces;
using PlacementTableApp.Repositories.Models;
using PlacementTableApp.Services.Interfaces;
using PlacementTableApp.Storage.Repositories;

namespace PlacementTableApp.Services
{
    public class ResultService : IResultService
    {
        private readonly IRepository<ResultEnty> _repo;

        public ResultService(IRepository<ResultEnty> repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<ResultView>> GetAllAsync()
        {
            var entities = _repo.GetAllAsync().Result;
            var views = entities.Select(e => Helpers.Mappers.ViewModel.ConvertResult(e));
            return Task.FromResult(views);
        }

        public Task GetById(int id)
        {
            var item = _repo.GetByIdAsync(id);
            return Task.FromResult(item);
        }

        public Task<ResultEnty> GetByTeamId(int teamId)
        {
            var items = _repo.GetAllAsync().Result;
            var item = items.Where(x => x.TeamId == teamId).FirstOrDefault();
            return Task.FromResult(item);
        }

        public Task CreateAsync(ResultView view)
        {
            var addItem = Helpers.Mappers.EntyModel.ConvertResult(view);
            _repo.AddAsync(addItem); 
            return Task.CompletedTask;
        }

        public Task CreateAsync(ResultEnty enty)
        {
            _repo.AddAsync(enty);
            return Task.CompletedTask;
        }

        public async Task UpdateTeamAsync(ResultView result)
        {
            var enty = Helpers.Mappers.EntyModel.ConvertResult(result);
            _ = _repo.UpdateAsync(enty);
        }
    }
}
