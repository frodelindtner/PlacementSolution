namespace PlacementTableApp.Services.Interfaces
{
    public interface IResultService
    {
        Task<IEnumerable<PlacementTableApp.Models.ViewModels.ResultView>> GetAllAsync();
        Task CreateAsync(PlacementTableApp.Models.ViewModels.ResultView view);
    }
}
