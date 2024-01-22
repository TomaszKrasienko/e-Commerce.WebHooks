using e_Commerce.WebHooks.Application.Services;
using e_Commerce.WebHooks.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace e_Commerce.WebHooks.Infrastructure.WebHooksDispatcher.Configuration;

public static class Extensions
{
    internal const string WebHookClient = "WebHookHttpClient";
    
    internal static IServiceCollection AddWebHookDispatcher(this IServiceCollection services)
        => services;

    private static IServiceCollection AddHttpClientFactory(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<WebHooksOptions>("WebHooks");
        var retryPolicy = Policy.HandleResult<HttpResponseMessage>(r
                => !r.IsSuccessStatusCode)
            .RetryAsync(options.Retries);
        services.AddHttpClient(WebHookClient, client =>
        {
            client.Timeout = options.TimeOut;
        }).AddPolicyHandler(retryPolicy);
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IWebHookDispatcher, HttpWebHookDispatcher>();
}