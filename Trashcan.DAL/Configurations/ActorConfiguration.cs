using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

/// <summary>
/// 
/// </summary>
public class ActorConfiguration :  IEntityTypeConfiguration<Actor>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(a => a.Lastname).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Firstname).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Secondname).HasMaxLength(100);
        builder.Property(a => a.PhoneNumber).HasMaxLength(12).IsRequired();
        builder.Property(a => a.City).HasMaxLength(100).IsRequired();
        builder.Property(a => a.Street).HasMaxLength(100).IsRequired();
        builder.Property(a => a.House).HasMaxLength(20).IsRequired();
        builder.Property(a => a.Apartament).HasMaxLength(20);
        builder.Property(a => a.Login).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Password).HasMaxLength(20).IsRequired();
        builder.Property(a => a.Status).IsRequired();
        builder.Property(a => a.Mailing).IsRequired();
    }
}