using e_Commerce.WebHooks.Core.Exceptions.Base;

namespace e_Commerce.WebHooks.Application.Exceptions;

public sealed class EventNotFoundException : CustomException
{
    public EventNotFoundException(Guid eventId) : base($"Event with ID: {eventId} does not exist")
    {
        
    }

    public EventNotFoundException(string typeName) : base($"Event with TypeName: {typeName} does not exist")
    {
    }
}