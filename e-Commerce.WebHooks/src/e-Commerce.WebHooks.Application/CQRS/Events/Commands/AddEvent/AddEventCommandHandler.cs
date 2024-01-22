using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;

internal sealed class AddEventCommandHandler : INotificationHandler<AddEventCommand>
{
    private readonly IEventRepository _eventRepository;

    public AddEventCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task Handle(AddEventCommand notification, CancellationToken cancellationToken)
    {
        var isEventExists = await _eventRepository.IsExistsAsync(notification.TypeName,
            notification.Id);
        var @event = new Event(notification.Id, notification.TypeName);
        await _eventRepository.AddAsync(@event);
    }
}