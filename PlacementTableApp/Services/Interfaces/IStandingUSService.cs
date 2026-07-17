using PlacementTableApp.Models.ViewModels;

namespace PlacementTableApp.Services.Interfaces
{
    public interface IStandingUSService
    {
        public Task<List<StandingView>> GetStandingsAsync(string league = null, string division = null);
    }
}
