using Microsoft.AspNetCore.Mvc;
using MovieLand.Application.Models;
using MovieLand.Application.Services.DTO;
using MovieLand.Application.Services.Interfaces.Services;

namespace MovieLand.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService ;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMovieAsync(CreateMovieDTO createMovie)
        {

            var movieId = await _movieService.CreateMovieAsync(createMovie);

            return Ok(movieId);


        }


        [HttpDelete("delete/{movieId}")]
        public async Task<IActionResult> DeleteProductAsync(
            int? bookId)
        {
            await _movieService.DeleteMovieAsync(bookId);
            return Ok(bookId);
        }

        [HttpPatch("update/{movieId}")]
        public async Task<IActionResult> UpdateMovieAsync(
            int? movieId,
            UpdateMovieDTO updateMovie)
        {
            await _movieService.UpdateMovieAsync(
                movieId,
                updateMovie);

            return Ok(movieId);
        }

        [HttpPost("update/{movieId}/price")]
        public async Task<IActionResult> UpdateMoviePriceAsync(
           int? movieId,
           UpdateMoviePriceDTO updateMoviePrice)
        {
            await _movieService.UpdateMoviePriceAsync(
                movieId,
                updateMoviePrice);

            return Ok(movieId);
        }

        [HttpGet("detail/{movieId}")]
        public async Task<IActionResult> GetMovieDetailsAsync(
            int? movieId)
        {
            var movie = await _movieService.GetMovieDetailsAsync(
               movieId);

            return Ok(movie);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetMovieListAsync(
            [FromQuery] int? genreId)
        {
            var movies = await _movieService.GetMovieListAsync(
                genreId);

            return Ok(movies);
        }

    }
}
