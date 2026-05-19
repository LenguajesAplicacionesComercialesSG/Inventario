using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Inventario.SI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string API_KEY_NAME = "X-API-KEY";
        
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            var apiKey = configuration["ApiKey"];

            if (!httpContext.Request.Headers.TryGetValue(API_KEY_NAME, out var headerApiKey))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("API Key no proporcionada");

                return;
            }

            if (apiKey != headerApiKey)
            {
                httpContext.Response.StatusCode = 403;
                await httpContext.Response.WriteAsync("API Key no válida");
                return;
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
