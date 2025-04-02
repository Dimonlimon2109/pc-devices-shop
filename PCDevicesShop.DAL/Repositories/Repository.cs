using Microsoft.EntityFrameworkCore;
using PCDevicesShop.DAL.Data;
using PCDevicesShop.DAL.Interfaces;

namespace PCDevicesShop.DAL.Repositories
{
    public class Repository<T>: IRepository<T> where T : class, new()
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(id, ct);
        }

        public async Task AddAsync(T entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(T entity, CancellationToken ct = default)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _dbSet.FindAsync(id, ct);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }
    }
}
