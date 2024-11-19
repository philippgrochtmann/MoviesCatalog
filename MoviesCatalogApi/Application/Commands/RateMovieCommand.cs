using MediatR;
using MovieCatalogApi.Application.Dtos;

namespace MovieCatalogApi.Application.Comands
{
    public class RateMovieCommand : IRequest<MovieDto>  
    {
        public int MovieId { get; set; }
        public int Rating { get; set; }
    }
}
