using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Adboard.Infrastructure.ComponentRegister;

public static class ComponentRegister
{
    public static IServiceCollection RegisterRepository(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<,,>), typeof(Repository<,,>));
        
        return services;
    }
}