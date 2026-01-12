using Core.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess.Repositories.Abstract;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity, new()
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);
    Task<List<TEntity>> GetPaginatedAsync(int page = 1, int size = 15, Expression<Func<TEntity, bool>>? filter = null, params Expression<Func<TEntity, object>>[] includes);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, bool tracking = false, params Expression<Func<TEntity, object>>[] includes);
    Task AddAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}
