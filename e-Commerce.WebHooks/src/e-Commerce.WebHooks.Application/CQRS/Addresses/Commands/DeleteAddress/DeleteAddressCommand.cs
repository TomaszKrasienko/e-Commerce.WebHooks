using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.DeleteAddress;

public sealed record DeleteAddressCommand(Guid Id) : INotification;