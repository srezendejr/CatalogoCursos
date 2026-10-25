using Cted.CatalogoCursos.Database;
using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.Repository.Repository;
using Cted.CatalogoCursos.Service.Interface;
using Cted.CatalogoCursos.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("CursoApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CursoApi:BaseUrl"] ?? "http://localhost:5000");
});
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

/*
 * Observação: a camada de serviço já está registrada e pode receber o repositório por injeção.
 */

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

var imageResourcesPath = Path.Combine(builder.Environment.ContentRootPath, "Recursos", "Imagens");
if (Directory.Exists(imageResourcesPath))
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(imageResourcesPath),
        RequestPath = "/Recursos/Imagens"
    });
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
