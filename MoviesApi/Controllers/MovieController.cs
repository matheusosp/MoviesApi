using Microsoft.AspNetCore.Mvc;
using MoviesApi.DataAccessLayer;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly IDataAccessLayer _dataAccessLayer;

    public MovieController(ILogger<MovieController> logger, IDataAccessLayer dataAccessLayer)
    {
        _logger = logger;
        _dataAccessLayer = dataAccessLayer;
    }

    [HttpGet("Title/{title}")]
    public IEnumerable<IMovie> GetMovieByTitle(string title)
    {
        _logger.LogInformation($"Searching for movies with the title: {title}");
        return _dataAccessLayer.GetMovieByTitle(title);
    }   

    [HttpGet("Year/{year}")]
    public IEnumerable<IMovie> GetMovieByYear(int year)
    {
        _logger.LogInformation($"Searching for movies from the year: {year}");
        return _dataAccessLayer.GetMovieByYear(year);
    }

    [HttpGet("Genre/{genre}")]
    public IEnumerable<IMovie> GetMovieByGenre(string genre)
    {
        _logger.LogInformation($"Searching for movies with the genre: {genre}");
        return _dataAccessLayer.GetMovieByGenre(genre);
    }

    [HttpGet("Cast/{castMember}")]
    public IEnumerable<IMovie> GetMovieByCast(string castMember)
    {
        _logger.LogInformation($"Searching for movies with the cast member: {castMember}");
        return _dataAccessLayer.GetMovieByCast(castMember);
    }
}
