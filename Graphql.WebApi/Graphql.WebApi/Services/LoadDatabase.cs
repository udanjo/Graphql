using Bogus;
using Graphql.WebApi.Entities;

namespace Graphql.WebApi.Services
{
    public static class LoadDatabase
    {
        public static IEnumerable<Book> Register()
        {
            return new Faker<Book>("pt_BR")
                .RuleFor(o => o.Title, f => f.Lorem.Word())
                .RuleFor(o => o.NumberPage, f => f.Random.Number(1, 1000))
                .RuleFor(o => o.Author, f => new Author { Name = f.Person.FullName })
                .Generate(10);
        }
    }
}