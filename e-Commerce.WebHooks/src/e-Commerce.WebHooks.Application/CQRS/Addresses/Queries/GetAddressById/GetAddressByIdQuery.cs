using e_Commerce.WebHooks.Application.DTOs;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Queries.GetAddressById;

public sealed record GetAddressByIdQuery(Guid Id) : IRequest<AddressDto>;