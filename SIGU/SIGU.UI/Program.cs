using Microsoft.EntityFrameworkCore;
using SIGU.Repositorios;
using SIGU.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//  Inyectar SIGUContext con EF Core y SQLite
builder.Services.AddDbContext<SIGUContext>(options =>
    options.UseSqlite("Data Source=SIGU.sqlite"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
