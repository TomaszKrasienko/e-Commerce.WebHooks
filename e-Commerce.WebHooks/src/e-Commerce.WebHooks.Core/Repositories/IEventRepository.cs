using e_Commerce.WebHooks.Core.Entities;

namespace e_Commerce.WebHooks.Core.Repositories;

public interface IEventRepository
{
    Task<IReadOnlyList<Event>> GetAllAsync();
    Task<Event> GetByIdAsync(Guid id);
    Task AddAsync(Event @event);
    Task UpdateAsync(Event @event);
    Task DeleteAsync(Guid id);
}