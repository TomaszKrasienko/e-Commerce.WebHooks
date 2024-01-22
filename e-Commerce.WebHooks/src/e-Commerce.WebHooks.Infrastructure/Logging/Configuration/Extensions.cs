using e_Commerce.WebHooks.Infrastructure.Logging.Decorators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.WebHooks.Infrastructure.Logging.Configuration;

internal static class Extensions
{
    internal static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        => services
            .AddDecorators();

    private static IServiceCollection AddDecorators(this IServiceCollection services)
    {
        services.TryDecorate(typeof(INotificationHandler<>), typeof(CommandHandlerLoggingDecorator<>));
        services.TryDecorate(typeof(IRequestHandler<,>), typeof(QueryHandlerLoggingDecorator<,>));
        return services;
    }
}