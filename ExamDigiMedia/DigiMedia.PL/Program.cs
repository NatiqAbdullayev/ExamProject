using DigiMedia.BL.Services.Abstract;
using DigiMedia.BL.Services.Concrete;
using DigiMedia.DAL.Contexts;
using DigiMedia.DAL.Models;
using DigiMedia.DAL.Repositories.Abstract;
using DigiMedia.DAL.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("defaultdb"));
});
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IProducService, ProductSerice>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(name: "Default", pattern: "{Controller=Home}/{Action=Index}");

using (var scope = app.Services.CreateScope())
{
    var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
    await accountService.CreateAdminAsync();
}

app.Run();
