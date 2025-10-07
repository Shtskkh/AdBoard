using Adboard.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Hosts.DbMigrator;

/// <summary>
/// Context for DB migration
/// </summary>
public class MigrationDbContext : ApplicationDbContext
{
    public MigrationDbContext(DbContextOptions options) : base(options)
    {
    } 
}