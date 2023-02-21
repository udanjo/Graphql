namespace Graphql.WebApi.Interfaces.Repositories
{
    public interface IMongoDbSettings
    {
        string Database { get; set; }
        string ConnectionString { get; set; }
    }
}
