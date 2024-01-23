using e_Commerce.WebHooks.Application.Configuration;
using e_Commerce.WebHooks.Infrastructure.Configuration;

namespace e_Commerce.WebHooks.Api.Configuration;

public static class Extensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddApplication()
            .AddInfrastructure(configuration)
            .AddControllersConfiguration();

    private static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }
}