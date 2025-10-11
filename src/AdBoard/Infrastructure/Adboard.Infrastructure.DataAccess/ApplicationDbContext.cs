using System.Reflection;
using Adboard.Domain.Entities;
using Adboard.Infrastructure.DataAccess.Context.Adverts.Configurations;
using Adboard.Infrastructure.DataAccess.Context.Roles.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    /// <summary>
    /// Таблица объявлений
    /// </summary>
    public DbSet<Advert> Adverts { get; set; }
    
    /// <summary>
    /// Таблица пользователей
    /// </summary>
    public DbSet<User> Users { get; set; }
    
    /// <summary>
    /// Таблица категорий объявлений
    /// </summary>
    public DbSet<Category> Categories { get; set; }
    
    /// <summary>
    /// Таблица подкатегорий объявлений
    /// </summary>
    public DbSet<Subcategory> Subcategories { get; set; }
    
    /// <summary>
    /// Таблица статусов аккаунтов пользователей
    /// </summary>
    public DbSet<AccountStatus> AccountsStatuses { get; set; }
    
    /// <summary>
    /// Таблица ролей пользователей
    /// </summary>
    public DbSet<Role> Roles { get; set; }
    
    /// <summary>
    /// Таблица комментариев под объявлениями
    /// </summary>
    public DbSet<AdvertComment> AdvertsComments { get; set; }
    
    /// <summary>
    /// Таблица фотографий объявлений
    /// </summary>
    public DbSet<AdvertPhoto> AdvertsPhotos { get; set; }

    /// <summary>
    /// Метод применения всех конфигураций, описанных в данном решении
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}