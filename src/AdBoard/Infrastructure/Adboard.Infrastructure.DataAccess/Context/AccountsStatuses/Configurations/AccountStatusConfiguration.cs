using Adboard.Domain.Entities;
using Adboard.Domain.Enums;
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
            .WithOne(x => x.AccountStatus)
            .HasForeignKey(x => x.AccountStatusId);

        builder.HasData(
            new AccountStatus { Id = (int)AccountStatusType.NeedsConfirm, Title = "Needs confirm" },
            new AccountStatus { Id = (int)AccountStatusType.Active, Title = "Active" },
            new AccountStatus { Id = (int)AccountStatusType.Blocked, Title = "Blocked" }, 
            new AccountStatus { Id = (int)AccountStatusType.Deleted, Title = "Deleted" }
            );
    }
}