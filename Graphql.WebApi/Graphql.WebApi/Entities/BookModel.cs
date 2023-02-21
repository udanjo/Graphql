using Graphql.WebApi.Abstractions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Graphql.WebApi.Entities
{
    [BsonCollection("BOOK")]
    public class Book
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }
        public int NumberPage { get; set; }
        public Author Author { get; set; }
    }

    [BsonCollection("AUTHOR")]
    public class Author
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}