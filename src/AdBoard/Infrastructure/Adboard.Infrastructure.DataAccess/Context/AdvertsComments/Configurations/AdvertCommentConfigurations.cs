using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.AdvertsComments.Configurations;

/// <summary>
/// Конфигурация для сущности комментария для объявления
/// </summary>
public class AdvertCommentConfigurations : IEntityTypeConfiguration<AdvertComment>
{
    public void Configure(EntityTypeBuilder<AdvertComment> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Text)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.AdvertComments)
            .HasForeignKey(x => x.UserId);
        
        builder.HasOne(x => x.Advert)
            .WithMany(x => x.AdvertComments)
            .HasForeignKey(x => x.AdvertId);
    }
}