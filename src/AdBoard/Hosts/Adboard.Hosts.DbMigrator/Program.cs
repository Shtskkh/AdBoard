using Microsoft.EntityFrameworkCore;

namespace Adboard.Hosts.DbMigrator;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
        {
            services.AddServices(hostContext.Configuration);
        }).Build();

        await MigrateAsync(host.Services);
        await host.RunAsync();
    }
    
    private static async Task MigrateAsync(IServiceProvider services)
    {
        var scope  = services.CreateScope();
        var context = scope.ServiceProvider.GetService<MigrationDbContext>();
        await context.Database.MigrateAsync();
    }
}