using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<IPieRepository , PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();




builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection")));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();

}

app.MapDefaultControllerRoute();
DbInitializr.Seed(app);
app.Run();
