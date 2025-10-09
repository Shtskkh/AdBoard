using Adboard.Infrastructure.DataAccess;
using Adboard.Infrastructure.ComponentRegister;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DbConnection")
));

builder.Services.RegisterRepository();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();