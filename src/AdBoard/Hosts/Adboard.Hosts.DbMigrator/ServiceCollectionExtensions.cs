using Microsoft.EntityFrameworkCore;

namespace Adboard.Hosts.DbMigrator;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDbConnection(configuration);
        
        return services;
    }

    private static IServiceCollection ConfigureDbConnection(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(connectionString));
        
        return services;
    }
}