using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Exceptions;
using FluentAssertions;

namespace e_Commerce.WebHooks.Core.Tests.Entities;

public sealed class EventTests
{
    [Fact]
    public void New_ForAllValidArguments_ShouldReturnNewEvent()
    {
        //arrange
        var id = Guid.NewGuid();
        var name = "testTypeName";
        
        //act
        var result = new Event(id, name);
        
        //assert
        result.Should().BeOfType<Event>();
        result.Id.Value.Should().Be(id);
        result.TypeName.Value.Should().Be(name);
        result.Addresses.Should().BeEmpty();
    }

    [Fact]
    public void New_ForEmptyId_ShouldThrowEmptyEntityIdException()
    {
        //act
        var exception = Record.Exception(() => new Event(Guid.Empty, "testTypeName"));
        
        //assert
        exception.Should().BeOfType<EmptyEntityIdException>();
    }

    [Fact]
    public void New_ForEmptyTypeName_ShouldThrowEmptyTypeNameException()
    {
        //act
        var exception = Record.Exception(() => new Event(Guid.NewGuid(), string.Empty));
        
        //assert
        exception.Should().BeOfType<EmptyTypeNameException>();
    }

    [Fact]
    public void AddAddress_ForNotExistingAddress_ShouldAddToAddresses()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testTypeName");
        var addressId = Guid.NewGuid();
        var addressUrl = "test_url";

        //act
        @event.AddAddress(addressId, addressUrl);
        
        //assert
        @event.Addresses.Any(x
            => x.Id.Value == addressId
               && x.Url == addressUrl
               && x.EventId == @event.Id).Should().BeTrue();
    }
    
    [Fact]
    public void AddAddress_ForExistingAddress_ShouldThrowAddressAlreadyRegisteredException()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testTypeName");
        var addressId = Guid.NewGuid();
        var addressUrl = "test_url";
        @event.AddAddress(addressId, addressUrl);

        //act
        var exception = Record.Exception(() => @event.AddAddress(addressId, addressUrl));
        
        //assert
        exception.Should().BeOfType<AddressAlreadyRegisteredException>();
    }

    [Fact]
    public void DeleteAddress_ForExistingAddress_ShouldDeleteAddressFromAddressesList()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testTypeName");
        var addressId = Guid.NewGuid();
        var addressUrl = "test_url";
        @event.AddAddress(addressId, addressUrl);
        
        //act
        @event.DeleteAddress(addressId);
        
        //assert
        @event.Addresses.Any(x => x.Id.Value == addressId).Should().BeFalse();
    }
    
    [Fact]
    public void DeleteAddress_ForNotExistingAddress_ShouldThrowAddressNotFoundException()
    {
        //arrange
        var @event = new Event(Guid.NewGuid(), "testTypeName");
        var addressId = Guid.NewGuid();
        
        //act
        var exception = Record.Exception(() => @event.DeleteAddress(addressId));
        
        //assert
        exception.Should().BeOfType<AddressNotFoundException>();
    }
}