using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Exceptions;
using e_Commerce.WebHooks.Application.Mappers;
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

    public async Task Handle(DispatchEventCommand notification, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByTypeNameAsync(notification.EventTypeName);
        if (@event is null)
        {
            throw new EventNotFoundException(notification.EventTypeName);
        }

        var dto = notification.AsDto();
        await _webHookDispatcher.Send(dto, @event.Addresses.Select(x => x.Url.Value).ToList(), cancellationToken);
    }
}