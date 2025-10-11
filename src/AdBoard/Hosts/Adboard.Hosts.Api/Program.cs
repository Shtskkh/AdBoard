using Adboard.Infrastructure.DataAccess;
using Adboard.Infrastructure.ComponentRegister;
using Adboard.Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;
using NSwag;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DbConnection")
));

builder.Services.RegisterRepository();
builder.Services.RegisterServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(options =>
{
    options.PostProcess = document =>
    {
        document.Info.Version = "0.4";
        document.Info.Title = "Adboard API";
        document.Info.Description = "Документация backend-сервера по курсу SolarLab 2025";
        document.Info.Contact = new OpenApiContact
        {
            Name = "Алексей Шацких",
            Email = "shtskkh@gmail.com",
            Url = "https://t.me/Shtskkh"
        };
    };
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseOpenApi();
app.UseSwaggerUi();

app.MapControllers();

app.Run();