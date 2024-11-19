using MediatR;
using AutoMapper;
using MovieCatalogApi.Application.Comands;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MovieCatalogApi.Enums;
using MoviesCatalogApi.Domain.Exceptions;

namespace MovieCatalog.Application.Commands.Movies
{
    public class MarkMovieAsWatchedCommandHandler : IRequestHandler<MarkMovieAsWatchedCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MarkMovieAsWatchedCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(MarkMovieAsWatchedCommand request, CancellationToken cancellationToken)
        {
            
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(nameof(movie), request.MovieId);

           
            movie.Status = MovieStatus.Watched;

            // Atualiza o filme no repositório e salva as mudanças
            await _movieRepository.UpdateAsync(movie);
            await _movieRepository.SaveChangesAsync();


            return _mapper.Map<MovieDto>(movie);
        }
    }
}
