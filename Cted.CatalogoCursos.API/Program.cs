using Cted.CatalogoCursos.Database;
using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.Repository.Repository;
using Cted.CatalogoCursos.Service.Interface;
using Cted.CatalogoCursos.Service.Service;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

var connectionString = new SqliteConnectionStringBuilder(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection is required."));

if (connectionString.DataSource != ":memory:" && !string.IsNullOrEmpty(connectionString.DataSource))
{
    connectionString.DataSource = Path.GetFullPath(
        connectionString.DataSource, builder.Environment.ContentRootPath);
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString.ToString()));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.MapControllers();

app.Run();
