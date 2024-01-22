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

    public Task Handle(DeleteAddressCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}