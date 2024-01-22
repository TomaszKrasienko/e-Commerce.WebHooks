using System.Collections.Immutable;
using e_Commerce.WebHooks.Application.CQRS.Addresses.Queries.GetAllAddresses;
using e_Commerce.WebHooks.Application.CQRS.Events.Queries.GetAllEvents;
using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using FluentAssertions;
using Moq;

namespace e_Commerce.WebHooks.Application.Tests.CQRS.Events.Queries;

public sealed class GetAllEventsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ForGetAllEventsQuery_ShouldReturnImmutableListOfEventDto()
    {
        //arrange
        var @event1 = new Event(Guid.NewGuid(), "TypeName1");
        var @event2 = new Event(Guid.NewGuid(), "TypeName2");
        _eventRepositoryMock
            .Setup(f => f.GetAllAsync())
            .ReturnsAsync(new List<Event>() { @event1, @event2 });
        
        //act
        var result = await _handler.Handle(new GetAllEventsQuery(), default);
        
        //assert
        result.Should().BeOfType<ImmutableList<EventDto>>();
        result.Should().NotBeEmpty();
    }
    
    #region arrange
    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly GetAllEventsQueryHandler _handler;

    public GetAllEventsQueryHandlerTests()
    {
        _eventRepositoryMock = new Mock<IEventRepository>();
        _handler = new GetAllEventsQueryHandler(_eventRepositoryMock.Object);
    }
    #endregion
}