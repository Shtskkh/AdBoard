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
    
    public DbSet<Advert> Adverts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }
    public DbSet<AccountStatus> AccountsStatuses { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AdvertComment> AdvertsComments { get; set; }
    public DbSet<AdvertPhoto> AdvertsPhotos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}