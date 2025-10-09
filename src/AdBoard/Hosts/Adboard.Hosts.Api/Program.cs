using Adboard.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DbConnection")
));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();