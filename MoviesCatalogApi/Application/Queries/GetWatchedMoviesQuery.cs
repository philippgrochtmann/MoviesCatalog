﻿using MediatR;
using MovieCatalogApi.Application.Dtos;

namespace MoviesCatalogApi.Application.Queries
{
    public class GetWatchedMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {
    }
}
