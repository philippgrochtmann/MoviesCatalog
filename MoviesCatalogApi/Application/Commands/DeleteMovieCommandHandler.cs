using MediatR;
using AutoMapper;
using MovieCatalogApi.Application.Comands;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MovieCatalogApi.Enums;
using MoviesCatalogApi.Domain.Exceptions;

namespace MovieCatalog.Application.Commands.Movies
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
          
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(nameof(movie), request.MovieId);

          
            await _movieRepository.DeleteAsync(movie);
            await _movieRepository.SaveChangesAsync();

    
            return _mapper.Map<MovieDto>(movie);
        }
    }
}
