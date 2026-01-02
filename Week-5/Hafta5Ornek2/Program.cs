using Hafta5Ornek2.Components;
using Hafta5Ornek2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddSingleton<Sayac>();

builder.Services.AddSingleton<UrunService>();	

//builder.Services.Add
//builder.Services.AddScoped  sayfa ýcerýsýnde kalýr sayfa gecýslerýnde degýsýr
//builder.Services.Add.Singleton	oturum saglandýgý surece kalýr 
//builder.Services.AddTransiet  her iþlem yapýldýgýnda calýsýr yenýlenýr


builder.Services.AddRazorComponents();

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
