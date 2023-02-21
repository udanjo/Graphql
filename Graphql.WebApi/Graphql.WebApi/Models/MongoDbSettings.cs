using Graphql.WebApi.Interfaces.Repositories;

namespace Graphql.WebApi.Models
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}
