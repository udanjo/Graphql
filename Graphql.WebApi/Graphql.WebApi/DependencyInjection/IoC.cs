using Graphql.WebApi.Interfaces.Repositories;
using Graphql.WebApi.Models;
using Graphql.WebApi.Repositories;

namespace Graphql.WebApi.DependencyInjection
{
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            //Mongo
            var mongoConnectionString = configuration.GetSection("MongoDbConfig:ConnectionString").Value;
            var mongoDatabase = configuration.GetSection("MongoDbConfig:Database").Value;

            var mongoConfig = new MongoDbSettings
            {
                ConnectionString = mongoConnectionString,
                Database = mongoDatabase
            };

            //Repository
            services.AddSingleton<IMongoDbSettings>(_ => mongoConfig);
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}