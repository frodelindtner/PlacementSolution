using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Repositories.Models;
using PlacementTableApp.Services.Interfaces;
using PlacementTableApp.Infrastructure;

namespace PlacementTableApp.Services
{
    public class ResultService : IResultService
    {
        private readonly IRepository<ResultEnty> _resultRepo;
        private readonly IRepository<TeamEnty> _teamRepo;

        public ResultService(IRepository<ResultEnty> resultRepo, IRepository<TeamEnty> teamRepo)
        {
            _resultRepo = resultRepo;
            _teamRepo = teamRepo;
        }

        public Task<IEnumerable<ResultView>> GetAllAsync()
        {
            var entities = _resultRepo.GetAllAsync().Result;
            var views = entities.Select(e => Helpers.Mappers.ViewModel.ConvertResult(e));
            return Task.FromResult(views);
        }

        public Task<ResultEnty> GetById(int resultId)
        {
            var item = _resultRepo.GetByIdAsync(resultId).Result;
            return Task.FromResult(item);
        }

        public Task<ResultEnty> GetByTeamId(int teamId)
        {
            var items = _resultRepo.GetAllAsync().Result;
            var item = items.Where(x => x.TeamId == teamId).FirstOrDefault();
            return Task.FromResult(item);
        }

        public Task CreateAsync(ResultView view)
        {
            var addItem = Helpers.Mappers.EntyModel.ConvertResult(view);
            _resultRepo.AddAsync(addItem); 
            return Task.CompletedTask;
        }

        public Task CreateAsync(ResultEnty enty)
        {
            _resultRepo.AddAsync(enty);
            return Task.CompletedTask;
        }

        public async Task UpdateResultAsync(ResultView result)
        {
            var enty = Helpers.Mappers.EntyModel.ConvertResult(result);
            await _resultRepo.UpdateAsync(enty);
        }
    }
}
