using e_Commerce.WebHooks.Application.Services;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Commands.DispatchEvent;

internal sealed class DispatchEventCommandHandler : INotificationHandler<DispatchEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IWebHookDispatcher _webHookDispatcher;

    public DispatchEventCommandHandler(IEventRepository eventRepository, IWebHookDispatcher webHookDispatcher)
    {
        _eventRepository = eventRepository;
        _webHookDispatcher = webHookDispatcher;
    }

    public Task Handle(DispatchEventCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}