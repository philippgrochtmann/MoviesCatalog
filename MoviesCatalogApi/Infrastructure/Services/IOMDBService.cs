using MovieCatalogApi.Infrastructure.Services.Models;

namespace MovieCatalogApi.Infrastructure.Services
{
    public interface IOMDBService
    {
        Task<MovieDetails> GetMovieDetailsAsync(string title);
    }
}
