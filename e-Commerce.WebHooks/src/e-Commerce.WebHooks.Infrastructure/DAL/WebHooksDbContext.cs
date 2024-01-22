using e_Commerce.WebHooks.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Commerce.WebHooks.Infrastructure.DAL;

internal sealed class WebHooksDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public WebHooksDbContext(DbContextOptions<WebHooksDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}