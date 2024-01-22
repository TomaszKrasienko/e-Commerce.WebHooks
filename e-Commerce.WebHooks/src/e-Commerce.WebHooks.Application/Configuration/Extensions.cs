using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Application.Configuration;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services.AddMediator();

    private static IServiceCollection AddMediator(this IServiceCollection services)
        => services.AddMediatR(cfg 
            => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
}