using PlacementTableApp.Storage.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementTableApp.Storage.Services
{
    public class ResultService : IResultService
    {
        private readonly IRepository<Result> _repository;

        public ResultService(IRepository<Result> repository)
        {
            _repository = repository;
        }

        public Task<Result?> GetAsync(int id) => _repository.GetByIdAsync(id);

        public Task<IEnumerable<Result>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Result> CreateAsync(Result result) => _repository.AddAsync(result);

        public Task UpdateAsync(Result result) => _repository.UpdateAsync(result);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
