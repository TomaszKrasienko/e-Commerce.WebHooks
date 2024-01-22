using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;

internal sealed class AddEventCommandHandler : INotificationHandler<AddEventCommand>
{
    public AddEventCommandHandler(IEventRepository eventRepository)
    {
        
    }
    
    public Task Handle(AddEventCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}