using MediatR;
using Microsoft.Extensions.Logging;

namespace e_Commerce.WebHooks.Infrastructure.Logging.Decorators;

internal sealed class QueryHandlerLoggingDecorator<T, TResponse> : IRequestHandler<T, TResponse>
    where T : IRequest<TResponse>
{
    private readonly ILogger<T> _logger;
    private readonly IRequestHandler<T, TResponse> _handler;

    public QueryHandlerLoggingDecorator(ILogger<T> logger, IRequestHandler<T, TResponse> handler)
    {
        _logger = logger;
        _handler = handler;
    }

    public async Task<TResponse> Handle(T request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handling {request.GetType()}");
        try
        {
            return await _handler.Handle(request, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw;
        }
    }
}