using e_Commerce.WebHooks.Application.Exceptions;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;

internal sealed class AddAddressCommandHandler : INotificationHandler<AddAddressCommand>
{
    private readonly IEventRepository _eventRepository;

    public AddAddressCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public async Task Handle(AddAddressCommand notification, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByTypeNameAsync(notification.EventTypeName);
        if (@event is null)
        {
            throw new EventNotFoundException(notification.Id);
        }
        
        @event.AddAddress(notification.Id, notification.Url);
        await _eventRepository.UpdateAsync(@event);
    }
}