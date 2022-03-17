using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    //Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // in REST pattern we dont specify the http verbs in the url
        // http://movieshop.com/api/movies/2 => JSON DATA returned in API
        // http://movieshop.com/movies/details/2 => VIEW returned in MVC

        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // api/movies/3
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            // return the data/json format
            // HTTP Status code, 200 OK
            // 404

            if (movie == null)
            {
                return NotFound(new { error = $"Movie Not Found for id: {id}" });
            }
            return Ok(movie);

            // in old .net for JSON serialization we used JSON.NET librray => very very popular
        }
    }
}
