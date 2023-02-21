using Graphql.WebApi.Entities;
using Graphql.WebApi.Interfaces.Repositories;

namespace Graphql.WebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoRepository<Book> _repository;

        public BookRepository(IMongoRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task Save(IEnumerable<Book> Models)
            => await _repository.SaveRangeAsync(Models);

        public async Task<IEnumerable<Book>> GetAll()
            => await _repository.GetAsync(null);

        public async Task<bool> Delete()
            => await _repository.DeleteAsync(null);
    }
}