using DevelopmentTodo.Api.Middlewaries;
using Microsoft.AspNetCore.Builder;

namespace DevelopmentTodo.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
