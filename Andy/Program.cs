using Andy.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Andy.Persistent;
using Andy.Core.Interfaces;
using Andy.Persistent.Repositorys;
using Andy.Core.Mappers;
using Andy.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AndyDbContext>(options =>
{
    var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AndyDatabase.db");
    options.UseSqlite($"Data Source={dbPath}");
});

//add mapper
builder.Services.AddSingleton<SubscriptionMapper>();

//add repositorys:
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

// Add services
builder.Services.AddScoped<ISubscitionService, SubscitionService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AndyDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
