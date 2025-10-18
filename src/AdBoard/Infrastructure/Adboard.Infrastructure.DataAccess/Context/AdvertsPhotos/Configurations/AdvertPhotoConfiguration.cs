using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.AdvertsPhotos.Configurations;

/// <summary>
/// Конфигурация для сущности фотографий объявления
/// </summary>
public class AdvertPhotoConfiguration : IEntityTypeConfiguration<AdvertPhoto>
{
    public void Configure(EntityTypeBuilder<AdvertPhoto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Advert)
            .WithMany(x => x.AdvertPhotos)
            .HasForeignKey(x => x.AdvertId);
    }
}