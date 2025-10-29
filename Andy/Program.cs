using Andy.Components;
using Andy.Core;
using Andy.Mapper;
using Andy.Persistent;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Andy
{
    public static partial class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseElectron(args);

            builder.Services.AddScoped<SubscriptionMapper>();

            builder.Services.AddCoreServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddFluentUIComponents();

            var app = builder.Build();

            if (HybridSupport.IsElectronActive)
            {
                Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
                {
                    Width = 1100,
                    Height = 800,
                    Show = false
                }).ContinueWith(task =>
                {
                    var window = task.Result;
                    window.OnReadyToShow += () => window.Show();
                    window.SetTitle("Andy Desktop App");
                    window.OnClosed += () => { Electron.App.Quit(); };
                });
            }

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
            app.MapRazorComponents<Andy.Components.App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}