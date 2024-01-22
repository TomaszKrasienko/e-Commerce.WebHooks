using System.Collections.Immutable;
using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Mappers;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Queries.GetAllAddresses;

internal sealed class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, IReadOnlyList<AddressDto>>
{
    private readonly IEventRepository _eventRepository;

    public GetAllAddressesQueryHandler(IEventRepository eventRepository)
        => _eventRepository = eventRepository;

    public async Task<IReadOnlyList<AddressDto>> Handle(GetAllAddressesQuery request,
        CancellationToken cancellationToken)
        => (await _eventRepository.GetAllAsync())
            .SelectMany(x => x.Addresses.Select(y => y.AsDto())).ToImmutableList();
}