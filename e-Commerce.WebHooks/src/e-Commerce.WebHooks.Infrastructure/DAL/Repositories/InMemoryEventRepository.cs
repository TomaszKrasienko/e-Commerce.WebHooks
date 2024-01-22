using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;

namespace e_Commerce.WebHooks.Infrastructure.DAL.Repositories;

internal sealed class InMemoryEventRepository : IEventRepository
{
    public Task<IReadOnlyList<Event>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetByTypeNameAsync(string typeName)
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetByAddressIdAsync(Guid addressId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Event @event)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Event @event)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistsAsync(string typeName, Guid id)
    {
        throw new NotImplementedException();
    }
}