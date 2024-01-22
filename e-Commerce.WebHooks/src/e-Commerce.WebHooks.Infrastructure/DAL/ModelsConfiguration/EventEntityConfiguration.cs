using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.ValueObjects;
using e_Commerce.WebHooks.Core.ValueObjects.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.WebHooks.Infrastructure.DAL.ModelsConfiguration;

internal sealed class EventEntityConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, y => new EntityId(y))
            .IsRequired();
        builder
            .Property(x => x.TypeName)
            .HasConversion(x => x.Value, y => new TypeName(y))
            .IsRequired();
        builder
            .HasMany<Address>(x => x.Addresses)
            .WithOne()
            .HasForeignKey(x => x.EventId);
    }
}