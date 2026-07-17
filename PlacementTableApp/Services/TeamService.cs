using Microsoft.AspNetCore.Http.HttpResults;
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

        public Task AddTeamAsync(TeamDTO team)
        {
            var addTeam = new TeamEnty { City = team.City, Division = team.Division, 
                Id = team.Id, League = team.League, Name = team.Name, Season = team.Season};

            var teamAdded = _repository.AddAsync(addTeam);
            return Task.CompletedTask;
        }

        public Task DeleteTeamAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<TeamDTO> GetTeamByIdAsync(int id)
        {
            var item = _repository.GetByIdAsync(id).Result ?? throw new Exception("Not Found");
            var dto = new TeamDTO(item.Id, item.Season, item.City, item.Name, item.Division, item.League);

            return dto;
        }

        public async Task<List<TeamDTO>> GetTeamsAsync()
        {
            var teams = await _repository.GetAllAsync();

            var teamsDtos = teams.Select(x => new TeamDTO(x.Id, x.Season, x.City, x.Name, x.Division, x.League));

            return [.. teamsDtos];
        }

        public async Task UpdateTeamAsync(TeamDTO team)
        {
            var enty = new TeamEnty { City = team.City, Division = team.Division, Id = team.Id, League = team.League,
                Name = team.Name, Season = team.Season};

            _ = _repository.UpdateAsync(enty);
        }
    }
}
