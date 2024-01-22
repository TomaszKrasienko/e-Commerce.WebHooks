using e_Commerce.WebHooks.Application.Configuration;
using e_Commerce.WebHooks.Infrastructure.Configuration;

namespace e_Commerce.WebHooks.Api.Configuration;

public static class Extensions
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
        => services
            .AddApplication()
            .AddInfrastructure();
    
}