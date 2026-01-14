
using Core.DataAccess.Repositories.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Repositories.Concrete.EFCore
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
        where TEntity : class, IEntity,new()
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _entities;
        public EfBaseRepository(TContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = CreateQuery(false, includes);

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = CreateQuery(false, includes);

            if (filter != null)
                query = query.Where(filter);

            return await query
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, bool tracking = false, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = CreateQuery(tracking, includes);
            return await query.FirstOrDefaultAsync(filter);
        }


        private IQueryable<TEntity> CreateQuery(bool tracking, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = tracking
                ? _entities
                : _entities.AsNoTracking();

            foreach (var include in includes)
                query = query.Include(include);

            return query;
        }
    }
}
