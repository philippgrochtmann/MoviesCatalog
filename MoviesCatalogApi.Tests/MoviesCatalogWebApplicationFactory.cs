using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MovieCatalogApi.Domain.Models;
using MovieCatalogApi.Enums;
using MovieCatalogApi.Infrastructure.Data;

internal class MoviesCatalogWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));

            // Configura o DbContext para usar InMemoryDatabase
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryMovieCatalogTest");
            });

            
            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            // Adiciona os dados mockados
            dbContext.Movies.AddRange(
                new Movie { Title = "The Dark Knight", Year = "2008", Director = "Christopher Nolan", Genre = "Action", UserRating = 5, Status = MovieStatus.Watched },
                new Movie { Title = "Inception", Year = "2010", Director = "Christopher Nolan", Genre = "Sci-Fi", UserRating = 4, Status = MovieStatus.Watched },
                new Movie { Title = "Interstellar", Year = "2014", Director = "Christopher Nolan", Genre = "Sci-Fi", Status = MovieStatus.Watchlist },
                new Movie { Title = "Pulp Fiction", Year = "1994", Director = "Quentin Tarantino", Genre = "Crime", Status = MovieStatus.Watchlist },
                new Movie { Title = "The Godfather", Year = "1972", Director = "Francis Ford Coppola", Genre = "Crime", UserRating = 5, Status = MovieStatus.Watched }
            );

            dbContext.SaveChanges();
        });
    }

}
