using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.Adverts.Configurations;

/// <summary>
/// Конфигурация для сущности объявления
/// </summary>
public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
{
    public void Configure(EntityTypeBuilder<Advert> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Adverts)
            .HasForeignKey(x => x.UserId);
        
        builder.HasMany(x => x.AdvertPhotos)
            .WithOne(x => x.Advert)
            .HasForeignKey(x => x.AdvertId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Subcategories)
            .WithMany(x => x.Adverts);
        
        builder.HasMany(x => x.AdvertComments)
            .WithOne(x => x.Advert)
            .HasForeignKey(x => x.AdvertId);
        
    }
}