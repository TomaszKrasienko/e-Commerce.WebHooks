using e_Commerce.WebHooks.Application.DTOs;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Queries.GetAllEvents;

public record GetAllEventsQuery : IRequest<IReadOnlyList<EventDto>>;