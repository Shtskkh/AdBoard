using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.AdvertsPhotos.Configurations;

public class AdvertPhotoConfiguration : IEntityTypeConfiguration<AdvertPhoto>
{
    public void Configure(EntityTypeBuilder<AdvertPhoto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Advert)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.AdvertId);
    }
}