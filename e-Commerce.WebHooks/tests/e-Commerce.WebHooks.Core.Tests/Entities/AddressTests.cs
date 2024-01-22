using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Exceptions;
using FluentAssertions;

namespace e_Commerce.WebHooks.Core.Tests.Entities;

public sealed class AddressTests
{
    [Fact]
    public void New_ForAllValidArguments_ShouldReturnNewAddress()
    {
        //arrange
        var id = Guid.NewGuid();
        var url = "url";
        var eventId = Guid.NewGuid();
        
        //act
        var result = new Address(id, url, eventId);
        
        //assert
        result.Should().BeOfType<Address>();
        result.Id.Value.Should().Be(id);
        result.Url.Value.Should().Be(url);
        result.EventId.Value.Should().Be(eventId);
    }
    
    [Fact]
    public void New_ForEmptyId_ShouldThrowEmptyEntityIdException()
    {
        //act
        var exception = Record.Exception(() => new Address(Guid.Empty, "url", Guid.NewGuid()));
        
        //assert
        exception.Should().BeOfType<EmptyEntityIdException>();
    }
    
    [Fact]
    public void New_ForEmptyUrl_ShouldThrowEmptyUrlException()
    {
        //act
        var exception = Record.Exception(() => new Address(Guid.NewGuid(), string.Empty, Guid.NewGuid()));
        
        //assert
        exception.Should().BeOfType<EmptyUrlException>();
    }
    
    [Fact]
    public void New_ForEmptyEventId_ShouldThrowEmptyEntityIdException()
    {
        //act
        var exception = Record.Exception(() => new Address(Guid.NewGuid(), "url", Guid.Empty));
        
        //assert
        exception.Should().BeOfType<EmptyEntityIdException>();
    }
}