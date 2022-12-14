using ASP.Net;
using OnlineShop.Db;
using OnlineShopWebApplication;
using Serilog;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostingContext, LoggerConfiguration) =>
{
    LoggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "Online Shop");
});

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop")));

builder.Services.AddTransient<IOrdersDbRepository, OrdersDbRepository>();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
builder.Services.AddSingleton<IUsersManager, UsersManager>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
