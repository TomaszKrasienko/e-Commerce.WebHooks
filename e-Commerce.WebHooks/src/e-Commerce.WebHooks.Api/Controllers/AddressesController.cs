using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;
using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.DeleteAddress;
using e_Commerce.WebHooks.Application.CQRS.Addresses.Queries.GetAllAddresses;
using e_Commerce.WebHooks.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace e_Commerce.WebHooks.Api.Controllers;

public sealed class AddressesController : BaseController
{
    public AddressesController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("{addressId:guid}")]
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
        => Ok(await Mediator.Send(new GetAllAddressesQuery(), cancellationToken));
    
    [HttpPost("add-address")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Add(AddAddressCommand command, CancellationToken cancellationToken)
    {
        var addressId = Guid.NewGuid();
        await Mediator.Publish(command with { Id = addressId }, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { addressId }, null);
    }

    [HttpDelete("{addressId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid addressId, CancellationToken cancellationToken)
    {
        await Mediator.Publish(new DeleteAddressCommand(addressId), cancellationToken);
        return NoContent();
    }
}