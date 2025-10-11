using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.Subcategories.Configurations;

/// <summary>
/// Конфигурация для сущности подкатегории объявления
/// </summary>
public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
{
    public void Configure(EntityTypeBuilder<Subcategory> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Subcategories)
            .HasForeignKey(x => x.CategoryId);

        builder.HasMany(x => x.Adverts)
            .WithMany(x => x.Subcategories);
    }
}