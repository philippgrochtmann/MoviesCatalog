﻿using Microsoft.AspNetCore.Http;

namespace MoviesCatalogApi.Domain.Interfaces.Middlewares
{
    public interface IExceptionHandlerMiddleware
    {
        Task Invoke(HttpContext context);
    }
}