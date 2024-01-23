using e_Commerce.WebHooks.Infrastructure.DAL.Configuration;
using e_Commerce.WebHooks.Infrastructure.Exceptions.Configuration;
using e_Commerce.WebHooks.Infrastructure.Logging.Configuration;
using e_Commerce.WebHooks.Infrastructure.Validation.Configuration;
using e_Commerce.WebHooks.Infrastructure.WebHooksDispatcher.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace e_Commerce.WebHooks.Infrastructure.Configuration;

public static class Extensions
{
    private const string Title = "e-Commerce.WebHooks";
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddExceptionHandling()
            .AddValidation()
            .AddLoggingConfiguration()
            .AddDal(configuration)
            .AddWebHookDispatcher(configuration)
            .AddSwaggerConfiguration();

    private static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.CustomSchemaIds(x => x.FullName);
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = Title,
                Version = "v1"
            });
        });
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
        => app
            .UseExceptionMiddleware()
            .UseUiDocumentation();

    private static WebApplication UseUiDocumentation(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(swagger =>
        {
            swagger.RoutePrefix = "swagger";
            swagger.DocumentTitle = Title;
        });
        app.UseReDoc(reDoc =>
        {
            reDoc.RoutePrefix = "redoc";
            reDoc.DocumentTitle = Title;
            reDoc.SpecUrl = "/swagger/v1/swagger.json";
        });
        return app;
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        T t = new T();
        configuration.Bind(sectionName, t);
        return t;
    }
}