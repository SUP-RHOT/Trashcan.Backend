using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(t => t.Name).HasMaxLength(150).IsRequired();
        builder.Property(t => t.Text).HasMaxLength(1500).IsRequired();

        builder.HasData(new List<Template>() { new Template() { Id = 1, Name = "string", Text = "string" } });
    }
}