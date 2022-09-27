using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesApi.Models;

public class MongoMovie : IMovie
{
    [BsonRepresentation(BsonType.ObjectId)] 
    public string Id { get; set; }

    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("year")]
    public int Year { get; set; }

    [BsonElement("cast")]
    public List<string> Cast { get; set; }

    [BsonElement("genres")]
    public List<string> Genres { get; set; }
}