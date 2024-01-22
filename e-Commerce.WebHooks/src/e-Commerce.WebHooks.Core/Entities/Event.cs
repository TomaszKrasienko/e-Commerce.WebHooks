using System.Data.Common;
using e_Commerce.WebHooks.Core.ValueObjects;
using e_Commerce.WebHooks.Core.ValueObjects.Event;

namespace e_Commerce.WebHooks.Core.Entities;

public sealed class Event
{
    public EntityId Id { get; private set; }
    public TypeName TypeName { get; private set; }

    public Event(EntityId id, TypeName typeName)
    {
        Id = id;
        TypeName = typeName;
    }
}