using Adboard.Infrastructure.DataAccess;
using Adboard.Infrastructure.ComponentRegister;
using Adboard.Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DbConnection")
));

builder.Services.RegisterRepository();
builder.Services.RegisterServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();
var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseOpenApi();
app.UseSwaggerUi();

app.MapControllers();

app.Run();