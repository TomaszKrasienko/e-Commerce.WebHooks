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

    [HttpPost("add-event")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerOperation("Adding new event")]
    public async Task<ActionResult> Add(AddEventCommand command)
    {
        var eventId = Guid.NewGuid();
        await Mediator.Publish(command with { Id = Guid.NewGuid() });
        return CreatedAtAction(nameof(GetById), new { eventId }, null);
    }

    [HttpGet("{eventId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerOperation("Getting event by Id")]
    public async Task<ActionResult<EventDto>> GetById(Guid id)
    {
        //Todo: To implement
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerOperation("Getting all events")]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetAll(CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetAllEventsQuery(), cancellationToken));
}