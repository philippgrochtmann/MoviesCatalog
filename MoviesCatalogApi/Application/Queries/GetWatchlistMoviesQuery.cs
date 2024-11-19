using MediatR;
using MovieCatalogApi.Application.Dtos;

namespace MoviesCatalogApi.Application.Queries
{
    public class GetWatchlistMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {
    }
}
