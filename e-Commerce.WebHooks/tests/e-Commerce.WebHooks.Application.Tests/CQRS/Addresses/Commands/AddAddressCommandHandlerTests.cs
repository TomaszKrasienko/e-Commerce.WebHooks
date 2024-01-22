using e_Commerce.WebHooks.Application.CQRS.Addresses.Commands.AddAddress;
using e_Commerce.WebHooks.Core.Repositories;
using Moq;

namespace e_Commerce.WebHooks.Application.Tests.CQRS.Addresses.Commands;

public class AddAddressCommandHandlerTests
{
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