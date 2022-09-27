using MoviesApi.Models;

namespace MoviesApi.DataAccessLayer;
public interface IDataAccessLayer
{
    public IEnumerable<IMovie> GetMovieByTitle(string title);
    public IEnumerable<IMovie> GetMovieByYear(int year);
    public IEnumerable<IMovie> GetMovieByCast(string castMember);
    public IEnumerable<IMovie> GetMovieByGenre(string genre);
}   