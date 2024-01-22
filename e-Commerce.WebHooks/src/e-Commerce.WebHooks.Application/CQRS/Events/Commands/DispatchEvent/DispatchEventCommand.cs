using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Commands.DispatchEvent;

public record DispatchEventCommand(string EventNumber, string EventTypeName) : INotification;