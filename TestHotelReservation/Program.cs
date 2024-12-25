using Microsoft.EntityFrameworkCore;
using TestHotelReservation.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurer le DbContext avec SQL Server
builder.Services.AddDbContext<LoginAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginAppDB")));

// Ajouter les services nécessaires
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Temps d'inactivité pour la session
    options.Cookie.HttpOnly = true; // Sécurité pour le cookie
    options.Cookie.IsEssential = true; // Obligatoire pour respecter le GDPR
});

// Ajouter le service d'accès au contexte HTTP
builder.Services.AddHttpContextAccessor(); // Nécessaire si vous utilisez IHttpContextAccessor

var app = builder.Build();

// Configurer le pipeline des requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Activer HSTS pour les scénarios de production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Activer l'utilisation des sessions
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
