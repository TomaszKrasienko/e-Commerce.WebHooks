using e_Commerce.WebHooks.Core.Repositories;
using e_Commerce.WebHooks.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Infrastructure.DAL.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddDal(this IServiceCollection services)
        => services.AddSingleton<IEventRepository, InMemoryEventRepository>();
}