using AutoMapper;
using MediatR;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MovieCatalogApi.Domain.Models;
using MovieCatalogApi.Infrastructure.Services;
using MoviesCatalogApi.Domain.Exceptions;


namespace MovieCatalogApi.Application.Comands
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IOMDBService _omdbService;
        private readonly IMapper _mapper;

        public AddMovieCommandHandler(IMovieRepository movieRepository, IOMDBService omdbService, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _omdbService = omdbService;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var existingMovie = await _movieRepository.GetByTitleAsync(request.Title);
            if (existingMovie != null)
                throw new BusinessException("Filme já está na watchlist.");

            var movieDetails = await _omdbService.GetMovieDetailsAsync(request.Title);

            if (movieDetails == null)
                throw new BusinessException("Filme não encontrado na OMDB API.");

            var movie = _mapper.Map<Movie>(movieDetails);

            await _movieRepository.AddAsync(movie);
            await _movieRepository.SaveChangesAsync();

            return _mapper.Map<MovieDto>(movie);
        }
    }
}
