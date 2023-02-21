using Graphql.WebApi.Entities;

namespace Graphql.WebApi.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task Save(IEnumerable<Book> Models);

        Task<IEnumerable<Book>> GetAll();

        Task<bool> Delete();
    }
}
