using Adboard.AppServices.Contexts.AccountsStatuses.Repositories;
using Adboard.AppServices.Contexts.AccountsStatuses.Services;
using Adboard.AppServices.Contexts.Adverts.Repositories;
using Adboard.AppServices.Contexts.Adverts.Services;
using Adboard.AppServices.Contexts.AdvertsPhotos;
using Adboard.AppServices.Contexts.Categories.Repositories;
using Adboard.AppServices.Contexts.Categories.Services;
using Adboard.AppServices.Contexts.Roles.Repositories;
using Adboard.AppServices.Contexts.Roles.Services;
using Adboard.AppServices.Contexts.Subcategories.Repositories;
using Adboard.AppServices.Contexts.Subcategories.Services;
using Adboard.AppServices.Contexts.Users.Repositories;
using Adboard.AppServices.Contexts.Users.Services;
using Adboard.AppServices.Facades.Users;
using Adboard.AppServices.Utilities.Passwords;
using Adboard.AppServices.Utilities.Tokens;
using Adboard.AppServices.Validators.Adverts;
using Adboard.AppServices.Validators.Categories;
using Adboard.AppServices.Validators.Users;
using Adboard.Infrastructure.ComponentRegister.MapProfiles;
using Adboard.Infrastructure.DataAccess.Context.AccountsStatuses.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Adverts.Repositories;
using Adboard.Infrastructure.DataAccess.Context.AdvertsPhotos.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Categories.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Roles.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Subcategories.Repositories;
using Adboard.Infrastructure.DataAccess.Context.Users.Repositories;
using Adboard.Infrastructure.DataAccess.Repositories;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Adboard.Infrastructure.ComponentRegister;

public static class ComponentRegister
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountStatusService, AccountStatusService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISubcategoryService, SubcategoryService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IAdvertService, AdvertService>();

        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        
        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UserProfile>();
            cfg.AddProfile<CategoryProfile>();
            cfg.AddProfile<SubcategoryProfile>();
            cfg.AddProfile<AdvertProfile>();
            cfg.AddProfile<AdvertPhotoProfile>();
        });
        
        configuration.AssertConfigurationIsValid();
        
        return configuration;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
        services.AddValidatorsFromAssemblyContaining<UserFilterValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateUserValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateAdvertValidator>();
        services.AddFluentValidationAutoValidation();
        
        return services;
    }
    
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IAccountStatusRepository, AccountStatusRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdvertRepository, AdvertRepository>();
        services.AddScoped<IAdvertPhotoRepository, AdvertPhotoRepository>();
        
        return services;
    }
}