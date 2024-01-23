using System.Collections.Immutable;
using e_Commerce.WebHooks.Core.Entities;

namespace e_Commerce.WebHooks.Core.Repositories;

public interface IEventRepository
{
    Task<IReadOnlyList<Event>> GetAllAsync();
    Task<Event> GetByIdAsync(Guid addressId);
    Task<Event> GetByTypeNameAsync(string typeName);
    Task<Event> GetByAddressIdAsync(Guid addressId);
    Task AddAsync(Event @event);
    Task UpdateAsync(Event @event);
    Task<bool> IsExistsAsync(string typeName, Guid id);
}