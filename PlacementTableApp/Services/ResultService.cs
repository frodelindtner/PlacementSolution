using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Domain.Models;
using PlacementTableApp.Services.Interfaces;
using PlacementTableApp.Infrastructure;

namespace PlacementTableApp.Services
{
    public class ResultService : IResultService
    {
        private readonly IRepository<ResultEnty> _resultRepository;

        public ResultService(IRepository<ResultEnty> resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public Task<IEnumerable<ResultView>> GetAllAsync()
        {
            var entities = _resultRepository.GetAllAsync().Result;
            var views = entities.Select(e => Helpers.Mappers.ViewModel.ConvertResult(e));
            return Task.FromResult(views);
        }

        public Task<ResultEnty?> GetById(int resultId)
        {
            var item = _resultRepository.GetByIdAsync(resultId).Result;
            return Task.FromResult(item);
        }

        public Task<ResultEnty?> GetByTeamId(int teamId)
        {
            var items = _resultRepository.GetAllAsync().Result;
            var item = items.Where(x => x.TeamId == teamId).FirstOrDefault();
            return Task.FromResult(item);
        }

        public Task CreateAsync(ResultView view)
        {
            var addItem = Helpers.Mappers.EntyModel.ConvertResult(view);
            _resultRepository.AddAsync(addItem); 
            return Task.CompletedTask;
        }

        public Task CreateAsync(ResultEnty enty)
        {
            _resultRepository.AddAsync(enty);
            return Task.CompletedTask;
        }

        public async Task UpdateResultAsync(ResultView result)
        {
            var enty = Helpers.Mappers.EntyModel.ConvertResult(result);
            await _resultRepository.UpdateAsync(enty);
        }
    }
}
