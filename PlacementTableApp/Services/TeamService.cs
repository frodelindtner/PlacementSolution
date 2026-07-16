using PlacementTableApp.Models.DTOs;
using PlacementTableApp.Storage.Entities;
using PlacementTableApp.Storage.Repositories;
using System.Linq;

namespace PlacementTableApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<TeamEnty> _repository;

        // Repository is injected via DI. Do not create DbContext here.
        public TeamService(IRepository<TeamEnty> repository)
        {
            _repository = repository;
        }

        public Task AddTeamAsync(TeamEnty team)
        {
            return _repository.AddAsync(team);
        }

        public Task DeleteTeamAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<TeamEnty> GetTeamByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<List<TeamDTO>> GetTeamsAsync()
        {
            var teams = await _repository.GetAllAsync();

            var teamsDtos = teams.Select(x => new TeamDTO(x.Id, x.Season, x.City, x.Name, x.Division, x.League));

            return teamsDtos.ToList();
        }

        public Task UpdateTeamAsync(TeamEnty team)
        {
            return _repository.UpdateAsync(team);
        }
    }
}
