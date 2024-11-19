

using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Domain.Models;

namespace MovieCatalogApi.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<Movie> Movies { get; set; }

    }
}
