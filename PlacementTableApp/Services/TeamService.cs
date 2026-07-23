using PlacementTableApp.Domain.Models;
using PlacementTableApp.Infrastructure;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Services.Interfaces;

namespace PlacementTableApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<TeamEnty> _teamRepository;
        private readonly IRepository<ResultEnty> _resultRepository;

        public TeamService(IRepository<TeamEnty> teamRepository, IRepository<ResultEnty> resultRepository)
        {
            _teamRepository = teamRepository;
            _resultRepository = resultRepository;
        }

        public List<string?> CreateFilers()
        {
            var teams = _teamRepository.GetAllAsync().Result;
            var dFilter = teams.Select(x => x.League).Distinct().ToList();
            return dFilter;
        }

        public async Task<Task> AddTeamAsync(TeamView team)
        {
            var addTeam = Helpers.Mappers.EntyModel.ConvertTeam(team);
            var newTeam = _teamRepository.AddAsync(addTeam).Result;
            var resultItem = new ResultEnty() {
                Id = 0,
                Losses = 0,
                Wins = 0,
                TeamId = newTeam.Id
            };
            _ = _resultRepository.AddAsync(resultItem).Result;
            return Task.CompletedTask;
        }

        public Task DeleteTeamAsync(int id)
        {
            return _teamRepository.DeleteAsync(id);
        }

        public async Task<TeamView> GetTeamByIdAsync(int id)
        {
            var item = _teamRepository.GetByIdAsync(id).Result ?? throw new Exception("Not Found");
            var dto = Helpers.Mappers.ViewModel.ConvertTeam(item);
            return dto;
        }

        public async Task<List<TeamView>> GetTeamsAsync()
        {
            var teams = await _teamRepository.GetAllAsync();
            var teamsDtos = teams.Select(x => Helpers.Mappers.ViewModel.ConvertTeam(x));
            return [.. teamsDtos];
        }

        public async Task UpdateTeamAsync(TeamView team)
        {
            var enty = Helpers.Mappers.EntyModel.ConvertTeam(team);
            await _teamRepository.UpdateAsync(enty);
        }
    }
}
