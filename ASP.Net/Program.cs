using ASP.Net;
using OnlineShop.Db;
using OnlineShopWebApplication;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, LoggerConfiguration) =>
{
    LoggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "Online Shop");
});

string connection = builder.Configuration.GetConnectionString("online_shop");

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connection)));

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connection)));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true,
    };
});

builder.Services.AddTransient<IOrdersDbRepository, OrdersDbRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
builder.Services.AddSingleton<IUsersManager, UsersManager>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseRouting();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
