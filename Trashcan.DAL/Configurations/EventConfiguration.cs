using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(e => e.Status).IsRequired();
        builder.Property(e => e.TypeMessage).HasMaxLength(100).IsRequired();
        builder.Property(e => e.TextMessage).HasMaxLength(1000).IsRequired();
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.Result).IsRequired();
    }
}