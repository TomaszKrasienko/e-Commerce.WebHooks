using e_Commerce.WebHooks.Core.Entities;
using e_Commerce.WebHooks.Core.ValueObjects;
using e_Commerce.WebHooks.Core.ValueObjects.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e_Commerce.WebHooks.Infrastructure.DAL.ModelsConfiguration;

internal sealed class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, y => new EntityId(y))
            .IsRequired();
        builder
            .Property(x => x.Url)
            .HasConversion(x => x.Value, y => new Url(y))
            .IsRequired();
        builder
            .Property(x => x.EventId)
            .HasConversion(x => x.Value, y => new EntityId(y))
            .IsRequired();
    }
}