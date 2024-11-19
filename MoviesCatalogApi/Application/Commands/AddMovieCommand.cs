using MediatR;
using MovieCatalogApi.Application.Dtos;

namespace MovieCatalogApi.Application.Comands
{
    public class AddMovieCommand : IRequest<MovieDto>
    {
        public required string Title { get; set; }
    }
}
