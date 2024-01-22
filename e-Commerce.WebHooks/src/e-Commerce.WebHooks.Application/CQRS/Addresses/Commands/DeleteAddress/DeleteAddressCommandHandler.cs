using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.DeleteAddress;

internal sealed class DeleteAddressCommandHandler : INotificationHandler<DeleteAddressCommand>
{
    public Task Handle(DeleteAddressCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}