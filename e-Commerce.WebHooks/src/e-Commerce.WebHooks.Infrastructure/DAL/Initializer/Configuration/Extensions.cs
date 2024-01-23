using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Infrastructure.DAL.Initializer.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDataInitializer(this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddHostedService()
            .AddOptions(configuration);

    private static IServiceCollection AddHostedService(this IServiceCollection services)
        => services.AddHostedService<DataInitializer>();
    
    private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<DataInitializerOptions>(configuration.GetSection("DataInitializer"));
}