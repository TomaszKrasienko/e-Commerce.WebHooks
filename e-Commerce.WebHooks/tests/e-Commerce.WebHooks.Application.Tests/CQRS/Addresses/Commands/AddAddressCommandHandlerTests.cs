using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;
using e_Commerce.WebHooks.Application.Exceptions;
using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using FluentAssertions;
using Moq;

namespace e_Commerce.WebHooks.Application.Tests.CQRS.Addresses.Commands;

public sealed class AddAddressCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForExistingEventAndNotExistingAddress_ShouldUpdateEventWithNewAddress()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testType");
        _eventRepositoryMock
            .Setup(f => f.GetByTypeNameAsync(It.Is<string>(x => x == @event.TypeName)))
            .ReturnsAsync(@event);
        var command = new AddAddressCommand(Guid.NewGuid(), "testUrl", @event.TypeName);
        
        //act
        await _handler.Handle(command, default);
        
        //assert
        _eventRepositoryMock
            .Verify(f => f.UpdateAsync(It.Is<Event>( x
                => x.Id == @event.Id
                && x.Addresses.Any(x => x.Id.Value == command.Id))));
    }
    
    [Fact]
    public async Task Handle_ForNotExistingEvent_ShouldThrowEventNotFoundException()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testType");
        _eventRepositoryMock
            .Setup(f => f.GetByTypeNameAsync(It.Is<string>(x => x == @event.TypeName)));
        var command = new AddAddressCommand(Guid.NewGuid(), "testUrl", @event.TypeName);
        
        //act
        var exception = await Record.ExceptionAsync(async () => await _handler.Handle(command, default));
        
        //assert
        exception.Should().BeOfType<EventNotFoundException>();
    }
    
    #region arrange

    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly AddAddressCommandHandler _handler;

    public AddAddressCommandHandlerTests()
    {
        _eventRepositoryMock = new Mock<IEventRepository>();
        _handler = new AddAddressCommandHandler();
    }
    #endregion
}