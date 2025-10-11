using Adboard.AppServices.Contexts.AccountsStatuses.Repositories;
using Adboard.AppServices.Contexts.AccountsStatuses.Services;
using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Contexts.Categories.Services;
using Adboard.AppServices.Contexts.Roles.Repositories;
using Adboard.AppServices.Contexts.Roles.Services;
using Adboard.AppServices.Contexts.Subcategories;
using Adboard.AppServices.Contexts.Subcategories.Services;
using Adboard.Infrastructure.DataAccess.Context.AccountsStatuses.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Categories.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Roles.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Subcategories.Repositories;
using Adboard.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Adboard.Infrastructure.ComponentRegister;

public static class ComponentRegister
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountStatusService, AccountStatusService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISubcategoryService, SubcategoryService>();
        
        return services;
    }
    
    public static IServiceCollection RegisterRepository(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IAccountStatusRepository, AccountStatusRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
        
        return services;
    }
}