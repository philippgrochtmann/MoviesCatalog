using MediatR;
using AutoMapper;
using MovieCatalogApi.Application.Comands;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MovieCatalogApi.Enums;
using MoviesCatalogApi.Domain.Exceptions;

namespace MovieCatalog.Application.Commands
{
    public class RateMovieCommandHandler : IRequestHandler<RateMovieCommand, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public RateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(RateMovieCommand request, CancellationToken cancellationToken)
        {
            
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(nameof(movie), request.MovieId);
            if (movie.Status != MovieStatus.Watched)
                throw new BusinessException("Não é possível avaliar um filme que não foi assistido.");

            if (request.Rating < 1 || request.Rating > 5)
                throw new BusinessException("A nota deve ser entre 1 e 5.");

            
            movie.UserRating = request.Rating;

            
            await _movieRepository.UpdateAsync(movie);
            await _movieRepository.SaveChangesAsync();


            return _mapper.Map<MovieDto>(movie);
        }
    }
}
