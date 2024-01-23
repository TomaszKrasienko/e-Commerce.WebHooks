using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Mappers;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Addresses.Queries.GetAddressById;

internal sealed class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
{
    private readonly IEventRepository _eventRepository;

    public GetAddressByIdQueryHandler(IEventRepository eventRepository)
        => _eventRepository = eventRepository;


    public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        => (await _eventRepository.GetByAddressIdAsync(request.Id))
            .Addresses.FirstOrDefault(x => x.Id.Value == request.Id)?.AsDto();
}