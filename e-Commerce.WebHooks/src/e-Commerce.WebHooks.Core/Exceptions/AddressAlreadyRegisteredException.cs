using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Core.Exceptions;

public sealed class AddressAlreadyRegisteredException(Guid addressId)
    : CustomException($"Address with ID: {addressId} already exists");