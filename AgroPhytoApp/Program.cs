using AgroPhytoApp.Models;
using AgroPhytoApp.Repositories;
using AgroPhytoApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Conexiunea la baza de date
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        "Server=(localdb)\\mssqllocaldb;Database=AgroPhytoDb;Trusted_Connection=True;"));

// Configurare Identity cu ApplicationUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Servicii aplicație
builder.Services.AddScoped<ProdusRepository>();
builder.Services.AddScoped<ProdusService>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Produse/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Rută principală
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produse}/{action=Index}/{id?}");

app.Run();