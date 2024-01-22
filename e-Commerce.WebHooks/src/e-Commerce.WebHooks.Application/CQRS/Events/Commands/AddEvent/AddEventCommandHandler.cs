using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;

internal sealed class AddEventCommandHandler : INotificationHandler<AddEventCommand>
{
    public AddEventCommandHandler()
    {
        
    }
    
    public Task Handle(AddEventCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}