using e_Commerce.WebHooks.Core.Repositories;
using e_Commerce.WebHooks.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Infrastructure.DAL.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDal(this IServiceCollection services)
        => services
            .AddDbContextConfiguration()
            .AddServices();

    private static IServiceCollection AddDbContextConfiguration(this IServiceCollection services)
    {
        services.AddDbContext<WebHooksDbContext>(options
            => options.UseInMemoryDatabase("e_commerce_web_hooks"));
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IEventRepository, EventRepository>();
    //.AddSingleton<IEventRepository, InMemoryEventRepository>();
}