using MediatR;
using Microsoft.Extensions.Logging;

namespace e_Commerce.WebHooks.Infrastructure.Logging.Decorators;

internal sealed class CommandHandlerLoggingDecorator<T> : INotificationHandler<T> where T : class, INotification
{
    private readonly ILogger<T> _logger;
    private readonly INotificationHandler<T> _handler;

    public CommandHandlerLoggingDecorator(ILogger<T> logger, INotificationHandler<T> handler)
    {
        _logger = logger;
        _handler = handler;
    }

    public async Task Handle(T notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handling {notification.GetType()}");
        try
        {
            await _handler.Handle(notification, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw;
        }
    }
}