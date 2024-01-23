using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Infrastructure.DAL.Initializer.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace e_Commerce.WebHooks.Infrastructure.DAL.Initializer;

internal sealed class DataInitializer : IHostedService
{
    private readonly ILogger<DataInitializer> _logger;
    private readonly DataInitializerOptions _options;
    private readonly IServiceProvider _serviceProvider;

    public DataInitializer(ILogger<DataInitializer> logger, 
        IOptions<DataInitializerOptions> options, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _options = options.Value;
        _serviceProvider = serviceProvider;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (_options.Enabled)
        {
            _logger.LogInformation("Initializing data");
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<WebHooksDbContext>();
            await dbContext.Events.AddRangeAsync(GetEvents(), cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    private List<Event> GetEvents()
    {
        var @event1 = new Event(Guid.NewGuid(), "test_type_name1");
        @event1.AddAddress(Guid.NewGuid(), "http://localhost:1111/test");
        @event1.AddAddress(Guid.NewGuid(), "http://localhost:1111/test2");
        @event1.AddAddress(Guid.NewGuid(), "http://localhost:1111/test3");
        @event1.AddAddress(Guid.NewGuid(), "http://localhost:1111/test4");
        
        var @event2 = new Event(Guid.NewGuid(), "test_type_name2");
        @event2.AddAddress(Guid.NewGuid(), "http://localhost:1000/test");
        @event2.AddAddress(Guid.NewGuid(), "http://localhost:1000/test2");
        @event2.AddAddress(Guid.NewGuid(), "http://localhost:1000/test3");
        @event2.AddAddress(Guid.NewGuid(), "http://localhost:1000/test4");

        return [@event1, @event2];
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}