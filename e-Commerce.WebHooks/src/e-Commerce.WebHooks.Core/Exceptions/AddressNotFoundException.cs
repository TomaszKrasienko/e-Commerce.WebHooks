using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Core.Exceptions;

public sealed class AddressNotFoundException(Guid addressId)
    : CustomException($"Address with ID: {addressId} does not exists");