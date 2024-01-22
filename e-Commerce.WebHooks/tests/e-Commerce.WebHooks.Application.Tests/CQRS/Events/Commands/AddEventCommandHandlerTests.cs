using e_Commerce.WebHooks.Application.CQRS.Events.Commands.AddEvent;
using e_Commerce.WebHooks.Application.Exceptions;
using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using FluentAssertions;
using Moq;

namespace e_Commerce.WebHooks.Application.Tests.CQRS.Events.Commands;

public sealed class AddEventCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForNotExistingEvent_ShouldAddEventByRepository()
    {
        //arrange
        var command = new AddEventCommand(Guid.NewGuid(), "testTypeName");
        _eventRepositoryMock
            .Setup(f => f.IsExistsAsync(
                It.Is<string>(x => x == command.TypeName),
                It.Is<Guid>(x => x == command.Id)))
            .ReturnsAsync(true);
        
        //act
        await _handler.Handle(command, default);
        
        //assert
        _eventRepositoryMock
            .Verify(f => f.AddAsync(It.Is<Event>(x
                => x.Id.Value == command.Id
                && x.TypeName.Value == command.TypeName)));
    }

    [Fact]
    public async Task Handle_ForExistingEvent_ShouldThrowEventAlreadyRegisteredException()
    {
        //arrange
        var command = new AddEventCommand(Guid.NewGuid(), "testTypeName");
        _eventRepositoryMock
            .Setup(f => f.IsExistsAsync(
                It.Is<string>(x => x == command.TypeName),
                It.Is<Guid>(x => x == command.Id)))
            .ReturnsAsync(false);
        
        //act
        var exception = await Record.ExceptionAsync(async () => await _handler.Handle(command, default));
        
        //assert
        exception.Should().BeOfType<EventAlreadyRegisteredException>();
    }
    
    #region arrange
    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly AddEventCommandHandler _handler;
    public AddEventCommandHandlerTests()
    {
        _eventRepositoryMock = new Mock<IEventRepository>();
        _handler = new AddEventCommandHandler(_eventRepositoryMock.Object);
    }
    #endregion
}