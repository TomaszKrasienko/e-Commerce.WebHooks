using System.Collections.Immutable;
using e_Commerce.WebHooks.Core.Exceptions;
using e_Commerce.WebHooks.Core.ValueObjects;
using e_Commerce.WebHooks.Core.ValueObjects.Event;

namespace e_Commerce.WebHooks.Core.Entities;

public sealed class Event
{
    private HashSet<Address> _addresses = new HashSet<Address>();
    public EntityId Id { get; private set; }
    public TypeName TypeName { get; private set; }
    public IEnumerable<Address> Addresses => _addresses.ToImmutableList();

    public Event(EntityId id, TypeName typeName)
    {
        Id = id;
        TypeName = typeName;
    }

    public void AddAddress(EntityId addressId, string url)
    {
        if (_addresses.Any(x => x.Id == addressId || x.Url == url))
        {
            throw new AddressAlreadyRegisteredException(addressId);
        }
        _addresses.Add(new Address(addressId, url, Id));
    }

    public void DeleteAddress(Guid addressId)
    {
        if (_addresses.All(x => x.Id.Value != addressId))
        {
            throw new AddressNotFoundException(addressId);
        }

        var address = _addresses.Single(x => x.Id.Value == addressId);
        _addresses.Remove(address);
    }
}