using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Formatters;
using PlacementTableApp.Models.ViewModels;
using PlacementTableApp.Repositories.Interfaces;
using PlacementTableApp.Repositories.Models;
using PlacementTableApp.Services.Interfaces;
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

        public List<string?> CreateFilers()
        {
            var teams = _repository.GetAllAsync().Result;
            var dFilter = teams.Select(x => x.League).Distinct().ToList();
            return dFilter;
        }

        public Task AddTeamAsync(TeamView team)
        {
            var addTeam = Helpers.Mappers.EntyModel.ConvertTeam(team);
            _ = _repository.AddAsync(addTeam);
            return Task.CompletedTask;
        }

        public Task DeleteTeamAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<TeamView> GetTeamByIdAsync(int id)
        {
            var item = _repository.GetByIdAsync(id).Result ?? throw new Exception("Not Found");
            var dto = Helpers.Mappers.ViewModel.ConvertTeam(item);
            return dto;
        }

        public async Task<List<TeamView>> GetTeamsAsync()
        {
            var teams = await _repository.GetAllAsync();
            var teamsDtos = teams.Select(x => Helpers.Mappers.ViewModel.ConvertTeam(x));
            return [.. teamsDtos];
        }

        public async Task UpdateTeamAsync(TeamView team)
        {
            var enty = Helpers.Mappers.EntyModel.ConvertTeam(team);
            _ = _repository.UpdateAsync(enty);
        }
    }
}
