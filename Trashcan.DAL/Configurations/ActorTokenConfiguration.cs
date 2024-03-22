using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashcan.Domain.Entity;

namespace Trashcan.DAL.Configurations;

public class ActorTokenConfiguration : IEntityTypeConfiguration<ActorToken>
{
    public void Configure(EntityTypeBuilder<ActorToken> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.RefreshToken).IsRequired();
        builder.Property(a => a.RefreshTokenExpiryTime).IsRequired();
    }
}