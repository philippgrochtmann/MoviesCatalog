using MediatR;
using AutoMapper;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MoviesCatalogApi.Application.Queries;

namespace MovieCatalog.Application.Queries
{
    public class GetFilteredMoviesQueryHandler : IRequestHandler<GetFilteredMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetFilteredMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetFilteredMoviesQuery request, CancellationToken cancellationToken)
        {
            // Busca filmes filtrados usando o repositório
            var movies = await _movieRepository.GetFilteredMoviesAsync(request.Genre, request.Year?.ToString());

            // Converte as entidades para DTOs
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
