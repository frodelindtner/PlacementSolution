using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementTableApp.Storage.Services
{
    public interface IResultService
    {
        Task<Result?> GetAsync(int id);
        Task<IEnumerable<Result>> GetAllAsync();
        Task<Result> CreateAsync(Result result);
        Task UpdateAsync(Result result);
        Task DeleteAsync(int id);
    }
}
