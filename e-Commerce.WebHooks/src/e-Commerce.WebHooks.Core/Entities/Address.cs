using e_Commerce.WebHooks.Core.ValueObjects;

namespace e_Commerce.WebHooks.Core.Entities;

public class Address
{
    public EntityId Id { get; private set; }
    public string Url { get; set; }
}