using MongoDB.Driver;

namespace FlightAssistant.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetOneAsync(FilterDefinition<TEntity> filter);
        Task CreateAsync(TEntity entity);
        Task DeleteAsync(FilterDefinition<TEntity> filter);
        Task UpdateAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);
    }
}
