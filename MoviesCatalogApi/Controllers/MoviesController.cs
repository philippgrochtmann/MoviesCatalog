using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogApi.Application.Comands;
using MovieCatalogApi.Application.Dtos;
using MoviesCatalogApi.Application.Queries;

namespace MovieCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] CreateMovieDto createMovieDto)
        {
            var command = new AddMovieCommand { Title = createMovieDto.Title };
            var result = await _mediator.Send(command);
            return Ok(result);

        }
        [HttpPut("/watch/{id}")]
        public async Task<IActionResult> MarkAsWatched(int id)
        {
            var command = new MarkMovieAsWatchedCommand { MovieId = id };
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        [HttpPut("/rate/{id}")]
        public async Task<IActionResult> RateMovie(int id, [FromBody] RateMovieDto rateMovieDto)
        {
            var command = new RateMovieCommand { MovieId = id, Rating = rateMovieDto.Rating };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var command = new DeleteMovieCommand { MovieId = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("watchlist")]
        public async Task<IActionResult> GetWatchlist()
        {
            var query = new GetWatchlistMoviesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("watched")]
        public async Task<IActionResult> GetWatchedMovies()
        {
            var query = new GetWatchedMoviesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var query = new GetMovieDetailsQuery { MovieId = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredMovies([FromQuery] GetFilteredMoviesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
