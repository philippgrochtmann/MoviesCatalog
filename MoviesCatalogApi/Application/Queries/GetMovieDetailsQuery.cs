using MediatR;
using MovieCatalogApi.Application.Dtos;

namespace MoviesCatalogApi.Application.Queries
{
    public class GetMovieDetailsQuery : IRequest<MovieDto>
    {
        public int MovieId { get; set; }
    }
}
