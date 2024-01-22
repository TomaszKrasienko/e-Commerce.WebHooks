using e_Commerce.WebHooks.Core.ValueObjects;

namespace e_Commerce.WebHooks.Core.Entities;

public sealed class Event
{
    public EntityId Id { get; private set; }
    public string TypeName { get; private set; }
}