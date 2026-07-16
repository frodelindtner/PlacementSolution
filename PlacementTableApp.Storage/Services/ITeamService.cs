using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementTableApp.Storage.Services
{
    public interface ITeamService
    {
        Task<Team?> GetAsync(int id);
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> CreateAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);
    }
}
