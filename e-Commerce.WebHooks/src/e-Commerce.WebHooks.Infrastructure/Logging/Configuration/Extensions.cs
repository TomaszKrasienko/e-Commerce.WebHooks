using e_Commerce.WebHooks.Infrastructure.Configuration;
using e_Commerce.WebHooks.Infrastructure.Logging.Decorators;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace e_Commerce.WebHooks.Infrastructure.Logging.Configuration;

public static class Extensions
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

    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
        var options = builder.Configuration.GetOptions<LoggingOptions>("Serilog");
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration
                .WriteTo.Console()
                .WriteTo.File(options.Path);
        });
        return builder;
    }
}