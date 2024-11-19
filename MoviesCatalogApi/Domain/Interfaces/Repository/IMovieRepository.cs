using MovieCatalogApi.Domain.Models;
using System.Linq.Expressions;

namespace MovieCatalogApi.Domain.Interfaces.Repository
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByTitleAsync(string title);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<IEnumerable<Movie>> FindAsync(Expression<Func<Movie, bool>> predicate);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Movie movie);
        Task SaveChangesAsync();
        Task<IEnumerable<Movie>> GetFilteredMoviesAsync(string genre, string year);
    }
}
