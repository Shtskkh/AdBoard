using Adboard.Domain.Entities;
using Adboard.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.Roles.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany(x => x.Users)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId);

        builder.HasData(
            new Role { Id = (int)RoleType.Admin, Title = "Admin" },
            new Role { Id = (int)RoleType.Moderator, Title = "Moderator" },
            new Role { Id = (int)RoleType.User, Title = "User" }
            );
    }
}