using MediatR;
using MovieCatalogApi.Application.Dtos;

namespace MoviesCatalogApi.Application.Queries
{
    public class GetFilteredMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {
        public string? Genre { get; set; }
        public int? Year { get; set; }
    }
}
