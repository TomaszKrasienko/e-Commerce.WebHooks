using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;

public record AddEventCommand(Guid Id, string TypeName) : INotification;