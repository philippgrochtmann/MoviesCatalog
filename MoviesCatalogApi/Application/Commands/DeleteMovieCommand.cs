using MediatR;
using MovieCatalogApi.Application.Dtos;

namespace MovieCatalogApi.Application.Comands
{
    public class DeleteMovieCommand : IRequest<MovieDto>
    {
        public int MovieId { get; set; }
    }
}
