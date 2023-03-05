using FlightAssistant.Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightAssistant.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> _collection;

        public Repository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<List<TEntity>> GetAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<TEntity> GetOneAsync(FilterDefinition<TEntity> filter)
        {
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
            return;
        }

        public async Task DeleteAsync(FilterDefinition<TEntity> filter)
        {
            await _collection.DeleteOneAsync(filter);
            return;
        }

        public async Task UpdateAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            await _collection.UpdateOneAsync(filter, update);
            return;
        }
    }
}
