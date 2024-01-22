using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Core.Repositories;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Queries.GetAllEvents;

internal sealed class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IReadOnlyList<EventDto>>
{
    private readonly IEventRepository _eventRepository;

    public GetAllEventsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public Task<IReadOnlyList<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}