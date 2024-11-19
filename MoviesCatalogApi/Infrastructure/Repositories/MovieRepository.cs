using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MovieCatalogApi.Domain.Models;
using MovieCatalogApi.Infrastructure.Data;
using System.Linq.Expressions;

namespace MovieCatalogApi.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Movie> _dbSet;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Movie>();
        }

        public async Task<Movie> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<Movie> GetByTitleAsync(string title)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Title == title);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> FindAsync(Expression<Func<Movie, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            await _dbSet.AddAsync(movie);
        }

        public Task UpdateAsync(Movie movie)
        {
            _dbSet.Update(movie);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Movie movie)
        {
            _dbSet.Remove(movie);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetFilteredMoviesAsync(string? genre, string? year)
        {
            IQueryable<Movie> query = _dbSet.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(genre))
            {
                var trimmedGenre = genre.Trim();

                // Adiciona vírgulas antes e depois da string Genre
                query = query.Where(m =>
                    EF.Functions.Like("," + m.Genre.Replace(" ", "") + ",", "%," + trimmedGenre + ",%"));
            }

            if (!string.IsNullOrWhiteSpace(year))
            {
                query = query.Where(m => m.Year == year);
            }

            return await query.ToListAsync();
        }
    }
}
