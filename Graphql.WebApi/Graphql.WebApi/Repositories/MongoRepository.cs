using Graphql.WebApi.Abstractions;
using Graphql.WebApi.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Graphql.WebApi.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(IMongoDbSettings dbSettings)
        {
            var database = new MongoClient(dbSettings.ConnectionString).GetDatabase(dbSettings.Database);
            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }

        public virtual async Task SaveAsync(T document, Expression<Func<T, bool>> filter)
        {
            var response = await FindOneAsync(filter);

            if (response != null)
            {
                await _collection.ReplaceOneAsync(filter, document);
                return;
            }

            await _collection.InsertOneAsync(document);
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var documents = filter != null ? _collection.Find(filter) : _collection.Find(new BsonDocument());

                return await documents.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual Task<T> FindOneAsync(Expression<Func<T, bool>> filter) => Task.Run(() => _collection.Find(filter).FirstOrDefaultAsync());

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var document = filter != null ? _collection.DeleteOneAsync(filter) : _collection.DeleteManyAsync(new BsonDocument());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public virtual async Task SaveRangeAsync(IEnumerable<T> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        protected string GetCollectionName(Type type)
        {
            return ((BsonCollectionAttribute)type
                    .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                    .FirstOrDefault())?.CollectionName;
        }
    }
}