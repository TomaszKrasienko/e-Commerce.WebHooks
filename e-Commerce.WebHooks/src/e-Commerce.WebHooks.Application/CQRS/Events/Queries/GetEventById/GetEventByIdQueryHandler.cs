using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Mappers;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Queries.GetEventById;

internal sealed class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto>
{
    private readonly IEventRepository _eventRepository;

    public GetEventByIdQueryHandler(IEventRepository eventRepository)
        => _eventRepository = eventRepository;

    public async Task<EventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        => (await _eventRepository.GetByIdAsync(request.Id))?.AsDto();
}