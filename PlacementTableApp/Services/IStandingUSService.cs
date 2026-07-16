using PlacementTableApp.Models.DTOs;

namespace PlacementTableApp.Services
{
    public interface IStandingUSService
    {
        public Task<List<StandingDTO>> GetStandingsAsync(string league = null, string division = null);
    }
}
