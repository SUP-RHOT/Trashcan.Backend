using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

public class AddressBaseConfiguration : IEntityTypeConfiguration<AddressBase>
{
    public void Configure(EntityTypeBuilder<AddressBase> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(a => a.Longitude).HasMaxLength(10);
        builder.Property(a => a.Width).HasMaxLength(10);
        builder.Property(a => a.City).HasMaxLength(100);
        builder.Property(a => a.Street).HasMaxLength(100);
        builder.Property(a => a.House).HasMaxLength(20);

        builder.HasData(new List<AddressBase> { new AddressBase() {Id = 1, City = "string", House = "string", Longitude = 0, Street = "string", Width = 0 } });
    }
}