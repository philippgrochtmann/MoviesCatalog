using AutoMapper;
using MediatR;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Interfaces.Repository;
using MoviesCatalogApi.Domain.Exceptions;

namespace MoviesCatalogApi.Application.Queries
{
    public class GetMovieDetailsQueryHandler : IRequestHandler<GetMovieDetailsQuery, MovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieDetailsQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
        {
            
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);

            if (movie == null)
                throw new NotFoundException(nameof(movie), request.MovieId);


            return _mapper.Map<MovieDto>(movie);
        }
    }
}
