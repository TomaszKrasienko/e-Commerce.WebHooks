using e_Commerce.WebHooks.Application.DTOs;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Queries.GetAllAdresses;

public sealed record GetAllAddressesQuery : IRequest<IReadOnlyList<AddressDto>>;