using PlacementTableApp.Storage.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementTableApp.Storage.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _repository;

        public TeamService(IRepository<Team> repository)
        {
            _repository = repository;
        }

        public Task<Team?> GetAsync(int id) => _repository.GetByIdAsync(id);

        public Task<IEnumerable<Team>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Team> CreateAsync(Team team) => _repository.AddAsync(team);

        public Task UpdateAsync(Team team) => _repository.UpdateAsync(team);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
