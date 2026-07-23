using PlacementTableApp.Models.ViewModels;

namespace PlacementTableApp.Services.Interfaces
{
    public interface ISportDataService
    {
        public Task<List<StandingView>> GetStandingsUSAsync(string league = null, string division = null);
    }
}
