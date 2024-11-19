using MediatR;
using AutoMapper;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MoviesCatalogApi.Application.Queries;
using MovieCatalogApi.Enums;

namespace MovieCatalog.Application.Queries
{
    public class GetWatchedMoviesQueryHandler : IRequestHandler<GetWatchedMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetWatchedMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetWatchedMoviesQuery request, CancellationToken cancellationToken)
        {
            // Busca filmes com status 'Watched'
            var movies = await _movieRepository.FindAsync(m => m.Status == MovieStatus.Watched);


            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

    }
}
