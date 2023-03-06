using FlightAssistant.Core.Models.Queries;
using FlightAssistant.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlightAssistant.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool include)
        {
            var queryable = context.Set<TEntity>().AsQueryable();

            if (include)
            {
                foreach (var property in context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    queryable = queryable.Include(property.Name);
            }

            return queryable.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<QueryResult<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> queryParams, Query queryBase)
        {
            var queryable = context.Set<TEntity>().AsQueryable();

            foreach (var property in context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                queryable = queryable.Include(property.Name);

            QueryResult<TEntity> queryResult = new QueryResult<TEntity>();

            if (queryParams != null)
            {
                queryable = queryable.Where(queryParams);
            }

            queryResult.TotalItems = await queryable.CountAsync();
            queryResult.Items = await queryable.Skip((queryBase.Page - 1) * queryBase.ItemsPerPage)
                                                    .Take(queryBase.ItemsPerPage)
                                                    .ToListAsync();

            return queryResult;
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool include)
        {
            var queryable = context.Set<TEntity>().AsQueryable();

            if (include)
            {
                foreach (var property in context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    queryable = queryable.Include(property.Name);
            }

            return await queryable.SingleOrDefaultAsync(predicate);
        }
    }
}
