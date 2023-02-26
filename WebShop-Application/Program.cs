using Microsoft.EntityFrameworkCore;
using WebShop_BussinessLayout.Data;
using WebShop_BussinessLayout.Interfaces;
using WebShop_BussinessLayout.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<WebShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<ICategoryRepository, CategoryServices>();
builder.Services.AddScoped<IProductRepository, ProductServices>();
builder.Services.AddScoped<IOrderDetailsRepository, OrderDetailsServices>();
builder.Services.AddScoped<IOrdersRepository, OrdersService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}");

app.Run();
