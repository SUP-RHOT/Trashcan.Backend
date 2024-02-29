using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(a => a.Longitude).HasMaxLength(10).IsRequired();
        builder.Property(a => a.Width).HasMaxLength(10).IsRequired();
        builder.Property(a => a.City).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Street).HasMaxLength(100).IsRequired();
        builder.Property(a => a.House).HasMaxLength(20).IsRequired();
    }
}