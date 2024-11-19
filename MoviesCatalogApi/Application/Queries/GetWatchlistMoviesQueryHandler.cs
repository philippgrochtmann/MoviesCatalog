using AutoMapper;
using MediatR;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MovieCatalogApi.Enums;

namespace MoviesCatalogApi.Application.Queries
{
    public class GetWatchlistMoviesQueryHandler : IRequestHandler<GetWatchlistMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetWatchlistMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> Handle(GetWatchlistMoviesQuery request, CancellationToken cancellationToken)
        {
            
            var movies = await _movieRepository.FindAsync(m => m.Status == MovieStatus.Watchlist);

            
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
