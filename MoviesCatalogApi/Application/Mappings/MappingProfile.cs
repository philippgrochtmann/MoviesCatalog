
using AutoMapper;
using MovieCatalogApi.Application.Dtos;
using MovieCatalogApi.Domain.Models;
using MovieCatalogApi.Enums;
using MovieCatalogApi.Infrastructure.Services.Models;


namespace MovieCatalogApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {



            // LeaveRequest mappings
            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDetails, Movie>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MovieStatus.Watchlist));

        }
    }
}
