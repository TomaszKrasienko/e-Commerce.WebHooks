using e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;
using e_Commerce.WebHooks.Application.CQRS.Events.Queries.GetAllEvents;
using e_Commerce.WebHooks.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace e_Commerce.WebHooks.Api.Controllers;

public sealed class EventsController : BaseController
{
    public EventsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{eventId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<EventDto>> GetById(Guid id)
    {
        //Todo: To implement
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetAll(CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetAllEventsQuery(), cancellationToken));
    
    [HttpPost("add-event")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(AddEventCommand command, CancellationToken cancellationToken)
    {
        var eventId = Guid.NewGuid();
        await Mediator.Publish(command with { Id = eventId }, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { eventId }, null);
    }
}