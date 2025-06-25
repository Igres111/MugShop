using Microsoft.EntityFrameworkCore;
using MugShop.Data;
using MugShop.Helpers;
using MugShop.Service.Implementations.CategoryRepos;
using MugShop.Service.Implementations.MugRepos;
using MugShop.Service.Interfaces.CategoriesInterfaces;
using MugShop.Service.Interfaces.MugInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMug, MugRepo>();
builder.Services.AddScoped<SKUGenerator>();
builder.Services.AddScoped<ICategory,CategoryRepo>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
