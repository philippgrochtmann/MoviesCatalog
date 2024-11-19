using MovieCatalogApi.Application.Dtos;
using System.Net.Http.Json;
namespace MoviesCatalogApi.Tests.Controllers;
public class MoviesControllerTests : IClassFixture<MoviesCatalogWebApplicationFactory>
{
    [Fact]
    public async Task AddMovie_ReturnsOk_WhenMovieIsAdded()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var createMovieDto = new CreateMovieDto
        {
            Title = "The Matrix"
        };
        var response = await _client.PostAsJsonAsync("/api/movies", createMovieDto);
        response.EnsureSuccessStatusCode(); 
        var result = await response.Content.ReadFromJsonAsync<MovieDto>();
        Assert.NotNull(result);
        Assert.Equal("The Matrix", result?.Title);
    }
    [Fact]
    public async Task AddMovie_ReturnsNok_WhenAlreadyExists_WhenMovieIsAdded()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var createMovieDto = new CreateMovieDto
        {
            Title = "The Dark Knight"
        };
        var response = await _client.PostAsJsonAsync("/api/movies", createMovieDto);
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
    [Fact]
    public async Task MarkAsWatched_ReturnsOk_WhenMovieIsMarkedAsWatched()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var movieId = 1; 
        var response = await _client.PutAsync($"/watch/{movieId}", null);
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task RateMovie_ReturnsOk_WhenMovieIsRated()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var movieId = 2;
        var rateMovieDto = new RateMovieDto { Rating = 5 };
        var response = await _client.PutAsJsonAsync($"/rate/{movieId}", rateMovieDto);
        response.EnsureSuccessStatusCode();
    }
    [Fact]
    public async Task RateMovie_ReturnsNok_WhenMovieIsNotWatched()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var movieId = 3;
        var rateMovieDto = new RateMovieDto { Rating = 5 };
        var response = await _client.PutAsJsonAsync($"/rate/{movieId}", rateMovieDto);
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode); 
    }


    [Fact]
    public async Task GetWatchlist_ReturnsOk_WhenWatchlistIsFetched()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var response = await _client.GetAsync("/api/movies/watchlist");
        response.EnsureSuccessStatusCode(); 
        var result = await response.Content.ReadFromJsonAsync<List<MovieDto>>();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetWatchedMovies_ReturnsOk_WhenWatchedMoviesAreFetched()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var response = await _client.GetAsync("/api/movies/watched");
        response.EnsureSuccessStatusCode(); 
        var result = await response.Content.ReadFromJsonAsync<List<MovieDto>>();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetMovieDetails_ReturnsOk_WhenMovieExists()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var movieId = 1; 
        var response = await _client.GetAsync($"/api/movies/{movieId}");
        response.EnsureSuccessStatusCode(); 
        var result = await response.Content.ReadFromJsonAsync<MovieDto>();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetMovieDetails_ReturnsNotFound_WhenMovieDoesNotExist()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var movieId = 999; 
        var response = await _client.GetAsync($"/api/movies/{movieId}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetFilteredMovies_ReturnsOk_WhenMoviesAreFiltered()
    {
        var application = new MoviesCatalogWebApplicationFactory();
        var _client = application.CreateClient();
        var queryString = "?Genre=Action&Year=2008";
        var response = await _client.GetAsync($"/api/movies/filter{queryString}");
        response.EnsureSuccessStatusCode(); 
        var result = await response.Content.ReadFromJsonAsync<List<MovieDto>>();
        Assert.NotNull(result);
    }
    
}


