using KingdomServerManager.DataAccessLayer.Configurations.Common;
using KingdomServerManager.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingdomServerManager.DataAccessLayer.Configurations;

internal class RoleConfiguration : BaseEntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.ToTable("Roles");

        builder.Property(r => r.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(r => r.Color)
            .HasMaxLength(50)
            .IsRequired();
    }
}