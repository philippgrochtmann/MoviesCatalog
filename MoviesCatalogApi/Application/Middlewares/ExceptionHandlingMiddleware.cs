using MoviesCatalogApi.Domain.Exceptions;
using MoviesCatalogApi.Domain.Interfaces.Middlewares;


namespace MoviesCatalogApi.Application.Middlewares
{
    public class ExceptionHandlingMiddleware : IExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new { ex.Message });
            }
            catch (BusinessException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { ex.Message });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { Message = "Ocorreu um erro inesperado." });
            }
        }
    }
}
