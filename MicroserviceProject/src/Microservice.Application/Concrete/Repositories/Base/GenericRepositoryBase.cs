using Microservice.Application.Abstract.Respositories.Base;
using Microservice.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Microservice.Application.Concrete.Repositories.Base
{
    public class GenericRepositoryBase<TEntity, TContext> : IGenericRepositoryBase<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext context;
        public GenericRepositoryBase(TContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(TEntity entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<List<TResult>> GetAllWithSelectAsync<TOrderBy, TResult>(
            Expression<Func<TEntity, TOrderBy>> orderBy,
            Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>>? where = null,
            bool isOrderBy = true)
        {
            return where is null
                ? isOrderBy
                    ? await context.Set<TEntity>().Select(select).ToListAsync()
                    : await context.Set<TEntity>().OrderByDescending(orderBy).Select(select).ToListAsync()
                : isOrderBy
                    ? await context.Set<TEntity>().Where(where).Select(select).ToListAsync()
                    : await context.Set<TEntity>().Where(where).OrderByDescending(orderBy).Select(select).ToListAsync();
        }

        public async Task<TResult?> GetWithSelectAsync<TOrderBy, TResult>(
            Expression<Func<TEntity, TOrderBy>> orderBy,
            Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>>? where = null,
            bool isOrderBy = true)
        {
            return where is null
                ? isOrderBy
                    ? await context.Set<TEntity>().Select(select).FirstOrDefaultAsync()
                    : await context.Set<TEntity>().OrderByDescending(orderBy).Select(select).FirstOrDefaultAsync()
                : isOrderBy
                    ? await context.Set<TEntity>().Where(where).Select(select).FirstOrDefaultAsync()
                    : await context.Set<TEntity>().Where(where).OrderByDescending(orderBy).Select(select).FirstOrDefaultAsync();

        }

        public async Task<TEntity?> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
