using PlacementTableApp.Models.DTOs;
using PlacementTableApp.Storage.Entities;

namespace PlacementTableApp.Services
{
    public interface ITeamService
    {
        public Task<List<TeamDTO>> GetTeamsAsync();
        public Task<TeamEnty> GetTeamByIdAsync(int id);

        public Task AddTeamAsync(TeamEnty team);
        public Task UpdateTeamAsync(TeamEnty team);
        public Task DeleteTeamAsync(int id);

    }
}
