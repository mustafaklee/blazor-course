using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Week13_new_self_auth.Components;
using Week13_new_self_auth.Models;
using Week13_new_self_auth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
));

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies(); // Cookie aktifleþtirir.

// Authentication Core (Cookie Auth eklemiyoruz, sadece temel Auth yapýsý)
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// --- SERVÝSLERÝN KAYDI ---
builder.Services.AddScoped<ProtectedSessionStorage>(); // Session Storage için
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(); // Bizim yazdýðýmýz Provider
builder.Services.AddScoped<AuthService>(); // DB iþlemleri için
// -------------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
