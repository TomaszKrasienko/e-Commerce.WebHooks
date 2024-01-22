using System.Collections.Immutable;
using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Mappers;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Queries.GetAllEvents;

internal sealed class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IReadOnlyList<EventDto>>
{
    private readonly IEventRepository _eventRepository;

    public GetAllEventsQueryHandler(IEventRepository eventRepository)
        => _eventRepository = eventRepository;

    public async Task<IReadOnlyList<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        => (await _eventRepository.GetAllAsync()).Select(x => x.AsDto()).ToImmutableList();
}