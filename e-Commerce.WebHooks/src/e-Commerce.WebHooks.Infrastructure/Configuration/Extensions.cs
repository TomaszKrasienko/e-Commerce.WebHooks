using e_Commerce.WebHooks.Infrastructure.Exceptions.Configuration;
using e_Commerce.WebHooks.Infrastructure.Logging.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Infrastructure.Configuration;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        => services
            .AddExceptionHandling()
            .AddLoggingConfiguration();

    public static WebApplication UseInfrastructure(this WebApplication app)
        => app.UseExceptionMiddleware();
}