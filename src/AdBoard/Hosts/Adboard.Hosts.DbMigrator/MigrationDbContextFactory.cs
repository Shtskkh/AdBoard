using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Adboard.Hosts.DbMigrator;

public class MigrationDbContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
{
    public MigrationDbContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var configuration = builder.Build();
        var connectionString = configuration.GetConnectionString("DbConnectionString");

        var contextBuilder = new DbContextOptionsBuilder<MigrationDbContext>();
        contextBuilder.UseNpgsql(connectionString);
        
        return new MigrationDbContext(contextBuilder.Options);
    }
}