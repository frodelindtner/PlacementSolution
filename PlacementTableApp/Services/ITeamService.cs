using PlacementTableApp.Models.DTOs;
using PlacementTableApp.Storage.Entities;

namespace PlacementTableApp.Services
{
    public interface ITeamService
    {
        public Task<List<TeamDTO>> GetTeamsAsync();
        public Task<TeamDTO> GetTeamByIdAsync(int id);

        public Task AddTeamAsync(TeamDTO team);
        public Task UpdateTeamAsync(TeamDTO team);
        public Task DeleteTeamAsync(int id);

    }
}
