using e_Commerce.WebHooks.Application.CQRS.Events.Commands.DispatchEvent;
using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Application.Exceptions;
using e_Commerce.WebHooks.Application.Services;
using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using e_Commerce.WebHooks.Core.ValueObjects.Event;
using FluentAssertions;
using Moq;

namespace e_Commerce.WebHooks.Application.Tests.CQRS.Events.Commands;

public sealed class DispatchEventCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForExistingEvent_ShouldSendByWebHookDispatcher()
    {
        //arrange
        var typeName = "test_type_name";
        var eventNumber = "123";
        var address1 = "testAddress1";
        var address2 = "testAddress2";
        var @event = new Event(Guid.NewGuid(), typeName);
        @event.AddAddress(Guid.NewGuid(), address1);
        @event.AddAddress(Guid.NewGuid(), address2);
        _eventRepositoryMock
            .Setup(f => f.GetByTypeNameAsync(It.Is<string>(arg => arg == typeName)))
            .ReturnsAsync(@event);
        var command = new DispatchEventCommand(eventNumber, typeName);
        
        //act
        await _handler.Handle(command, default);
        
        //assert
        _webHookDispatcherMock
            .Verify(x => x.Send(
                It.Is<WebHookDto>(arg => arg.EventNumber == eventNumber && arg.EventTypeName == typeName),
                It.Is<List<string>>(arg => arg.Contains(address1) && arg.Contains(address2))));
    }

    [Fact]
    public async Task Handle_ForNotExistingEvent_ShouldThrowEventNotFoundException()
    {
        //arrange
        var command = new DispatchEventCommand("123test", "test");
        
        //act
        var exception = await Record.ExceptionAsync(async () => await _handler.Handle(command, default));
        
        //assert
        exception.Should().BeOfType<EventNotFoundException>();
    }
    
    #region arrange

    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly Mock<IWebHookDispatcher> _webHookDispatcherMock;
    private readonly DispatchEventCommandHandler _handler;
    
    public DispatchEventCommandHandlerTests()
    {
        _eventRepositoryMock = new Mock<IEventRepository>();
        _webHookDispatcherMock = new Mock<IWebHookDispatcher>();
        _handler = new DispatchEventCommandHandler(_eventRepositoryMock.Object, _webHookDispatcherMock.Object);
    }
    
    #endregion
}