using System.Reflection.Metadata;
using CSharpAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();

    [HttpPost(Name = "Create new Movie")]
    public void AddMovie([FromBody] Movie movie)
    {
        movie.Id = 1;
        movies.Add(movie);
    }

    [HttpGet(Name = "Get all Movies")]
    public IEnumerable<Movie> GetMovies()
    {
        return movies;
    }

    [HttpGet( "{id:int}", Name = "Get Movie")]
    public IActionResult GetMovie(int id)
    {
        foreach (Movie movie in movies)
        {
            if (movie.Id == id)
            {
                return Ok(movie);
            }
        }
        return NotFound();
    }
    // // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }
}