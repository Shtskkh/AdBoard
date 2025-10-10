using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.Users.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.FirstName)
            .IsRequired();

        builder.Property(x => x.MiddleName);
        
        builder.Property(x => x.LastName)
            .IsRequired();

        builder.Property(x => x.PhoneNumber);
        
        builder.Property(x => x.Email)
            .IsRequired();
        
        builder.Property(x => x.Password)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);
        
        builder.HasOne(x => x.AccountStatus)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.AccountStatusId);
        
        builder.HasMany(x => x.Adverts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        
        builder.HasMany(x => x.AdvertComments)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}