using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Application.Exceptions;

public sealed class EventNotFoundForAddressException(Guid addressId)
: CustomException($"Event with address with ID: {addressId} not found");