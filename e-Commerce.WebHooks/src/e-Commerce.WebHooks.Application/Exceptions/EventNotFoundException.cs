using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Application.Exceptions;

public sealed class EventNotFoundException(Guid eventId)
    : CustomException($"Event with ID: {eventId} does not exist");