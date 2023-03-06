using FlightAssistant.Core.Models.Queries;
using System.Linq.Expressions;

namespace FlightAssistant.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<QueryResult<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> queryParams, Query queryBase);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool include);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool include);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
