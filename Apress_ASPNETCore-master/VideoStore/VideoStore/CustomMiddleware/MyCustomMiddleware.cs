using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace VideoStore.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MyCustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("MiddlewareLogger");
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogInformation("**** Info Middleware Invoke Called ****");
            _logger.LogWarning("**** Warning Middleware Invoke Called ****");
            _logger.LogError("**** Error Middleware Invoke Called ****");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
