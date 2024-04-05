using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
{
    public void Configure(EntityTypeBuilder<Institution> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(i => i.Name).HasMaxLength(150).IsRequired();
        builder.Property(i => i.City).HasMaxLength(100).IsRequired();
        builder.Property(i => i.District).HasMaxLength(100);
        builder.Property(i => i.Description).HasMaxLength(500);

        builder.HasData(new List<Institution>() { new Institution() { Id = 1, City = "string", Description = "string", District = "string", Name = "string" } });
    }
}