using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.DeleteAddress;
using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using Moq;

namespace e_Commerce.WebHooks.Application.Tests.CQRS.Addresses.Commands;

public sealed class DeleteAddressCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForExistingEventAndAddress_ShouldUpdateEventWithoutAddress()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testTypeName");
        var addressId = Guid.NewGuid();
        @event.AddAddress(addressId, "testUrl");

        _eventRepositoryMock
            .Setup(f => f.GetByAddressIdAsync(It.Is<Guid>(x
                => x == addressId)))
            .ReturnsAsync(@event);
        
        var command = new DeleteAddressCommand(addressId);
        
        //act
        await _handler.Handle(command, default);
        
        //assert
        _eventRepositoryMock
            .Verify(f => f.UpdateAsync(It.Is<Event>(x 
                => x.Id == @event.Id
                && !x.Addresses.Any(x => x.Id.Value == addressId))));
    }
    
    [Fact]
    public async Task Handle_ForNotExistingEvent_ShouldThrowEventNotFoundForAddress()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testTypeName");
        var addressId = Guid.NewGuid();
        @event.AddAddress(addressId, "testUrl");

        _eventRepositoryMock
            .Setup(f => f.GetByAddressIdAsync(It.Is<Guid>(x
                => x == addressId)))
            .ReturnsAsync(@event);
        
        var command = new DeleteAddressCommand(addressId);
        
        //act
        await _handler.Handle(command, default);
        
        //assert
        _eventRepositoryMock
            .Verify(f => f.UpdateAsync(It.Is<Event>(x 
                => x.Id == @event.Id
                   && x.Addresses.All(arg => arg.Id.Value != addressId))));
    }
    
    #region arrange
    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly DeleteAddressCommandHandler _handler;

    public DeleteAddressCommandHandlerTests()
    {
        _eventRepositoryMock = new Mock<IEventRepository>();
        _handler = new DeleteAddressCommandHandler(_eventRepositoryMock.Object);
    }
    #endregion
}