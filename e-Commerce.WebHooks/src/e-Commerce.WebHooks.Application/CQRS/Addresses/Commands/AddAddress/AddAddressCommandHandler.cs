using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;

internal sealed class AddAddressCommandHandler : INotificationHandler<AddAddressCommand>
{
    public AddAddressCommandHandler()
    {
        
    }
    
    public Task Handle(AddAddressCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}