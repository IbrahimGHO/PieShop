using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication2.App;
using WebApplication2.Models;
using WebApplication2.Models.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository , CategoryRepository>();
builder.Services.AddScoped<IPieRepository , PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));


builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();




builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler= ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

//builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection")));

var connectionString = builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BethanysPieShopDbContextConnection' not found.");

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<BethanysPieShopDbContext>();

builder.Services.AddControllers();
var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();

}

app.MapDefaultControllerRoute();
app.UseAntiforgery();

app.MapRazorPages();
app.MapControllers();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
DbInitializr.Seed(app);
app.Run();
