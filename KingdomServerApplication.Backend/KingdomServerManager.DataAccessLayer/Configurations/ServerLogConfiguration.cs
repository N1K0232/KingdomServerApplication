using KingdomServerManager.DataAccessLayer.Configurations.Common;
using KingdomServerManager.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KingdomServerManager.DataAccessLayer.Configurations;

internal class ServerLogConfiguration : BaseEntityConfiguration<ServerLog>
{
    public override void Configure(EntityTypeBuilder<ServerLog> builder)
    {
        base.Configure(builder);

        builder.ToTable("ServerLogs");

        builder.Property(l => l.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(l => l.Description)
            .HasMaxLength(512)
            .IsRequired();

        builder.Property(l => l.LogDate)
            .IsRequired();

        builder.Property(l => l.LogType)
            .HasConversion<string>()
            .HasMaxLength(25)
            .IsRequired();

        builder.HasOne(l => l.User)
            .WithMany(u => u.ServerLogs)
            .HasForeignKey(l => l.IdUser)
            .IsRequired();
    }
}