using Microservice.Domain.Common;
using System.Linq.Expressions;

namespace Microservice.Application.Abstract.Respositories.Base
{
    public interface IGenericRepositoryBase<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(int id);
        Task<List<TResult>> GetAllWithSelectAsync<TOrderBy, TResult>(
            Expression<Func<T, TOrderBy>> orderBy,
            Expression<Func<T, TResult>> select, Expression<Func<T, bool>>? where = null,
            bool isOrderBy = true);
        Task<TResult?> GetWithSelectAsync<TOrderBy, TResult>(
            Expression<Func<T, TOrderBy>> orderBy,
            Expression<Func<T, TResult>> select, Expression<Func<T, bool>>? where = null,
            bool isOrderBy = true);
        Task RemoveAsync(T entity);
    }
}
