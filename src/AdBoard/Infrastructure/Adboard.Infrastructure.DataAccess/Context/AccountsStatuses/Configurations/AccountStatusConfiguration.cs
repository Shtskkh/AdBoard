using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.AccountStatuses.Configurations;

public class AccountStatusConfiguration : IEntityTypeConfiguration<AccountStatus>
{
    public void Configure(EntityTypeBuilder<AccountStatus> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany(x => x.Users)
            .WithOne(x => x.Status)
            .HasForeignKey(x => x.StatusId);
    }
}