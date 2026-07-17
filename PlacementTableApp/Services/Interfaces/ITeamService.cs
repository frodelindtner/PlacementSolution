using PlacementTableApp.Models.ViewModels;

namespace PlacementTableApp.Services.Interfaces
{
    public interface ITeamService
    {
        public Task<List<TeamView>> GetTeamsAsync();
        public Task<TeamView> GetTeamByIdAsync(int id);

        public Task<Task> AddTeamAsync(TeamView team);
        public Task UpdateTeamAsync(TeamView team);
        public Task DeleteTeamAsync(int id);

        public List<string?> CreateFilers();
    }
}
