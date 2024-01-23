using e_Commerce.WebHooks.Application.DTOs;
using MediatR;

namespace e_Commerce.WebHooks.Application.CQRS.Events.Queries.GetEventById;

public record GetEventByIdQuery(Guid Id) : IRequest<EventDto>;