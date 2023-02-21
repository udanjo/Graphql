using System.Linq.Expressions;

namespace Graphql.WebApi.Interfaces.Repositories
{
    public interface IMongoRepository<T>
    {
        Task SaveAsync(T document, Expression<Func<T, bool>> filter);
        Task SaveRangeAsync(IEnumerable<T> documents);
        Task<T> FindOneAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);
    }
}
