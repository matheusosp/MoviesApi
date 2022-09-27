using MoviesApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MoviesApi.DataAccessLayer;

public class MongoDBDataAccessLayer : IDataAccessLayer
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<BsonDocument> _collection;
    private readonly ILogger<MongoDBDataAccessLayer> _logger;
    public MongoDBDataAccessLayer(ILogger<MongoDBDataAccessLayer> logger)
    {
        _logger = logger;
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://<username>:<password>@cluster0.gwwoeh0.mongodb.net/?retryWrites=true&w=majority");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        _client = new MongoClient(settings);
        _database = _client.GetDatabase("moviesdb");
        _collection = _database.GetCollection<BsonDocument>("movies");
    }

    public IEnumerable<IMovie> GetMovieByTitle(string title)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("title", title);

        var movieDocs = _collection.Find(filter);

        var moviesFound = movieDocs.CountDocuments();

        _logger.LogInformation($"{moviesFound} movies found with the title {title}");

        if (moviesFound == 0) 
        {
            _logger.LogInformation($"No movie named {title} found");
            return new List<MongoMovie>();
        }

        return ProcessQueryResult(movieDocs);
    }

    public IEnumerable<IMovie> GetMovieByYear(int year)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("year", year);

        var movieDocs = _collection.Find(filter);

        var moviesFound = movieDocs.CountDocuments();

        _logger.LogInformation($"{moviesFound} movies found for the year {year}");

        if (moviesFound == 0) 
        {
            _logger.LogInformation($"No movie from year {year} found");
            return new List<MongoMovie>();
        }

        var movieDocsList = movieDocs.ToList();

        // _logger.LogInformation($"Found movies {movieDoc.ToString()}");

        return ProcessQueryResult(movieDocs);
    }

    public IEnumerable<IMovie> GetMovieByCast(string castMember)
    {
        var filter = Builders<BsonDocument>.Filter.AnyEq("cast", castMember);

        var movieDocs = _collection.Find(filter);

        var moviesFound = movieDocs.CountDocuments();

        _logger.LogInformation($"{moviesFound} movies found with the cast member {castMember}");

        if (moviesFound == 0) 
        {
            _logger.LogInformation($"No movie with cast member {castMember} found");
            return new List<MongoMovie>();
        }

        // _logger.LogInformation($"Found movie {movieDoc.ToString()}");

        return ProcessQueryResult(movieDocs);
    }

    public IEnumerable<IMovie> GetMovieByGenre(string genre)
    {
        var filter = Builders<BsonDocument>.Filter.AnyEq("genres", genre);

        var movieDocs = _collection.Find(filter);

        var moviesFound = movieDocs.CountDocuments();

        _logger.LogInformation($"{moviesFound} movies found with the genre {genre}");

        if (moviesFound == 0)  
        {
            _logger.LogInformation($"No movie with genre {genre} found");
            return new List<MongoMovie>();
        }

        // _logger.LogInformation($"Found movie {movieDoc.ToString()}");

        return ProcessQueryResult(movieDocs);
    }

    private List<MongoMovie> ProcessQueryResult(IFindFluent<BsonDocument,BsonDocument> movieDocs)
    {
        var moviesList = new List<MongoMovie>();
        foreach (var movieDoc in movieDocs.ToList())
        {
            var movie = BsonSerializer.Deserialize<MongoMovie>(movieDoc);
            moviesList.Add(movie);
        }

        return moviesList;
    }
}