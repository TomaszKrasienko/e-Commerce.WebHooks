using e_Commerce.WebHooks.Application.Exceptions;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.DeleteAddress;

internal sealed class DeleteAddressCommandHandler : INotificationHandler<DeleteAddressCommand>
{
    private readonly IEventRepository _eventRepository;

    public DeleteAddressCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task Handle(DeleteAddressCommand notification, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByAddressIdAsync(notification.Id);
        if (@event is null)
        {
            throw new EventNotFoundForAddressException(notification.Id);
        }
        @event.DeleteAddress(notification.Id);
        await _eventRepository.UpdateAsync(@event);
    }
}