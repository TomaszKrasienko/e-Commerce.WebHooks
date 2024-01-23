using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace e_Commerce.WebHooks.Infrastructure.DAL.Repositories;

internal sealed class EventRepository : IEventRepository
{
    private readonly WebHooksDbContext _context;

    public EventRepository(WebHooksDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Event>> GetAllAsync()
        => await _context.Events
            .Include(x => x.Addresses)
            .ToListAsync();

    public async Task<Event> GetByIdAsync(Guid addressId)
        => await _context.Events
            .Include(c => c.Addresses)
            .SingleOrDefaultAsync(x => x.Id.Value == addressId);

    public Task<Event> GetByTypeNameAsync(string typeName)
        => _context
            .Events
            .Include(x => x.Addresses)
            .SingleOrDefaultAsync(x => x.TypeName == typeName);

    public Task<Event> GetByAddressIdAsync(Guid addressId)
        => _context
            .Events
            .Include(x => x.Addresses)
            .SingleOrDefaultAsync(x => x.Addresses.Any(y => y.Id.Value == addressId));

    public async Task AddAsync(Event @event)
    {
        await _context.Events.AddAsync(@event);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Event @event)
    {
        _context.Events.Update(@event);
        await _context.SaveChangesAsync();
    }

    public Task<bool> IsExistsAsync(string typeName, Guid id)
        => _context.Events.AnyAsync(y => y.TypeName == typeName || y.Id.Value == id);

}