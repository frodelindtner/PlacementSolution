using PlacementTableApp.Models.ViewModels;

namespace PlacementTableApp.Services.Interfaces
{
    public interface IStandingService
    {
        public Task<List<StandingView>> GetStandingLocalAsync(string league = null, string division = null);
    }
}
