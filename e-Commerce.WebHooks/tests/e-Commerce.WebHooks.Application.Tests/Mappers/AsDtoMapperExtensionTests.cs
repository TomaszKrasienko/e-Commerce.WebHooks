using e_Commerce.WebHooks.Application.CQRS.Events.Commands.DispatchEvent;
using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Mappers;
using e_Commerce.WebHooks.Core.Entities;
using FluentAssertions;

namespace e_Commerce.WebHooks.Application.Tests.Mappers;

public class AsDtoMapperExtensionsTests
{
    [Fact]
    public void AsDto_ForEvent_ShouldReturnEventDto()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "TestTypeName");
        
        //act
        var result = @event.AsDto();
        
        //assert
        result.Should().BeOfType<EventDto>();
        result.Id.Should().Be(@event.Id);
        result.TypeName.Should().Be(@event.TypeName);
    }

    [Fact]
    public void AsDto_ForAddress_ShouldReturnAddressDto()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "TestTypeName");
        var addressId = Guid.NewGuid();
        var addressUrl = "testUrl";
        @event.AddAddress(addressId, addressUrl);
        var address = @event.Addresses.Single(x => x.Id.Value == addressId);
        
        //act
        var result = address.AsDto();
        
        //assert
        result.Should().BeOfType<AddressDto>();
        result.Id.Should().Be(addressId);
        result.Url.Should().Be(addressUrl);
        result.EventId.Should().Be(@event.Id.Value);
    }

    [Fact]
    public void AsDto_ForDispatchEventCommand_ShouldReturnWebHookDto()
    {
        //arrange
        var command = new DispatchEventCommand("testNumber", "testTypeName");
        
        //act
        var result = command.AsDto();
        
        //assert
        result.Should().BeOfType<WebHookDto>();
        result.EventNumber.Should().Be(command.EventNumber);
        result.EventTypeName.Should().Be(command.EventTypeName);
    }
}