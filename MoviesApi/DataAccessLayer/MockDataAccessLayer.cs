using MoviesApi.Models;

namespace MoviesApi.DataAccessLayer;
public class MockDataAccessLayer : IDataAccessLayer
{
    public IEnumerable<IMovie> GetMovieByTitle(string title)
    {
        var movie = new MockMovie();
        movie.Title = title;
        movie.Year = 2000;
        movie.Cast = new List<string> { "Hugh Jackman", "Nicole Kidman" };
        movie.Genres = new List<string> { "Horror", "Thriller" };

        return new List<MockMovie>() { movie };
    }

    public IEnumerable<IMovie> GetMovieByYear(int year)
    {
        var movie = new MockMovie();
        movie.Title = "The Prestige";
        movie.Year = year;
        movie.Cast = new List<string> { "Hugh Jackman", "Nicole Kidman" };
        movie.Genres = new List<string> { "Horror", "Thriller" };

        return new List<MockMovie>() { movie };
    }

    public IEnumerable<IMovie> GetMovieByGenre(string genre)
    {
        var movie = new MockMovie();
        movie.Title = "The Prestige";
        movie.Year = 2000;
        movie.Cast = new List<string> { "Hugh Jackman", "Nicole Kidman" };
        movie.Genres = new List<string> { genre };

        return new List<MockMovie>() { movie };
    }

    public IEnumerable<IMovie> GetMovieByCast(string castMember)
    {
        var movie = new MockMovie();
        movie.Title = "The Prestige";
        movie.Year = 2000;
        movie.Cast = new List<String> { castMember };
        movie.Genres = new List<string> { "Horror", "Thriller" };

        return new List<MockMovie>() { movie };
    }
}