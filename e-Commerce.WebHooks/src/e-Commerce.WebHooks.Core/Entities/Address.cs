using e_Commerce.WebHooks.Core.ValueObjects;
using e_Commerce.WebHooks.Core.ValueObjects.Address;

namespace e_Commerce.WebHooks.Core.Entities;

public class Address
{
    public EntityId Id { get; private set; }
    public Url Url { get; private set; }
    public EntityId EventId { get; private set; }
}