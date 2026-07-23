using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlacementTableApp.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StandingDbContext _context;

        public Repository(StandingDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
            //return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            var entry = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
