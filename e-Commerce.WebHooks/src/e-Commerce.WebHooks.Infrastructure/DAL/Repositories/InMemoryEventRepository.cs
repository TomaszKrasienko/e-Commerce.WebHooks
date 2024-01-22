using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;

namespace e_Commerce.WebHooks.Infrastructure.DAL.Repositories;

internal sealed class InMemoryEventRepository : IEventRepository
{
    private readonly List<Event> _hosts = new List<Event>();

    public Task<IReadOnlyList<Event>> GetAllAsync()
        => Task.FromResult((IReadOnlyList<Event>)_hosts);


    public Task<Event> GetByTypeNameAsync(string typeName)
        => Task.FromResult(_hosts.SingleOrDefault(x => x.TypeName == typeName));

    public Task<Event> GetByAddressIdAsync(Guid addressId)
        => Task.FromResult(_hosts.SingleOrDefault(x => x.Addresses.Any(y => y.Id.Value == addressId)));

    public Task AddAsync(Event @event)
    {
        _hosts.Add(@event);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Event @event)
    {
        return Task.CompletedTask;
    }

    public Task<bool> IsExistsAsync(string typeName, Guid id)
        => Task.FromResult(_hosts.Any(y => y.TypeName == typeName || y.Id.Value == id));
}