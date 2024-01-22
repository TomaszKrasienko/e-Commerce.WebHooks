using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;

public sealed record AddAddressCommand(Guid Id, string Url, string EventTypeName) : INotification;