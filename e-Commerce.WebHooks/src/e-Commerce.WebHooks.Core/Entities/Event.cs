using System.Collections.Immutable;
using e_Commerce.WebHooks.Core.ValueObjects;
using e_Commerce.WebHooks.Core.ValueObjects.Event;

namespace e_Commerce.WebHooks.Core.Entities;

public sealed class Event
{
    private HashSet<Address> _addresses = new HashSet<Address>();
    public EntityId Id { get; private set; }
    public TypeName TypeName { get; private set; }
    public IReadOnlyList<Address> Addresses => _addresses.ToImmutableList();

    public Event(EntityId id, TypeName typeName)
    {
        Id = id;
        TypeName = typeName;
    }
}