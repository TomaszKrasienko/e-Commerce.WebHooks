using e_Commerce.WebHooks.Infrastructure.Exceptions.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Infrastructure.Exceptions.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        => services.AddSingleton<ExceptionMiddleware>();

    internal static WebApplication UseExceptionMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}