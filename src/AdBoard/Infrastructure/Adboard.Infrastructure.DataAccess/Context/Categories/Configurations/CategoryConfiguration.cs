using Adboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adboard.Infrastructure.DataAccess.Context.Categories.Configurations;

/// <summary>
/// Конфигурация для сущности категории объявления
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany(x => x.Subcategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}