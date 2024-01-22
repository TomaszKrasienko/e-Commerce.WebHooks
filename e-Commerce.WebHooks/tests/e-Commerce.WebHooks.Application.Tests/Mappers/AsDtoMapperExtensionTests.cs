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
}