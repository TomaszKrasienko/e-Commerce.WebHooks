using System.Collections.Immutable;
using e_Commerce.WebHooks.Application.CQRS.Addresses.Queries.GetAllAddresses;
using e_Commerce.WebHooks.Application.DTOs;
using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using FluentAssertions;
using Moq;

namespace e_Commerce.WebHooks.Application.Tests.CQRS.Addresses.Queries;

public sealed class GetAllAddressesQueryHandlerTests
{
    [Fact]
    public async Task Handle_ForQuery_ShouldReturnImmutableAddressesDtoList()
    {
        //arrange
        var @event1 = new Event(Guid.NewGuid(), "TypeName1");
        @event1.AddAddress(Guid.NewGuid(), "testUrl1");
        @event1.AddAddress(Guid.NewGuid(), "testUrl2");
        var @event2 = new Event(Guid.NewGuid(), "TypeName2");
        @event1.AddAddress(Guid.NewGuid(), "testUrl3");
        @event1.AddAddress(Guid.NewGuid(), "testUrl4");

        _eventRepositoryMock
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(new List<Event>() { @event1, @event2 });
        
        //act
        var result = await _handler.Handle(new GetAllAddressesQuery(), default);
        
        //assert
        result.Should().BeOfType<ImmutableList<AddressDto>>();
        result.Should().NotBeEmpty();
    }
    
    #region arrange

    private readonly Mock<IEventRepository> _eventRepositoryMock;
    private readonly GetAllAddressesQueryHandler _handler;

    public GetAllAddressesQueryHandlerTests()
    {
        _eventRepositoryMock = new Mock<IEventRepository>();
        _handler = new GetAllAddressesQueryHandler(_eventRepositoryMock.Object);
    }
    #endregion endregion
}