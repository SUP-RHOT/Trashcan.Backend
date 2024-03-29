using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(r => r.Name).HasMaxLength(25).IsRequired();

        builder.HasData(new List<Role>()
        {
            new Role()
            {
                Id = 1,
                Name = "Модератор"
            },
            new Role()
            {
                Id = 2,
                Name = "Администратор"
            }
        });
    }
}