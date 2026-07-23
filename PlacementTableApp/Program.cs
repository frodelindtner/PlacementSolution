using Microsoft.EntityFrameworkCore;
using PlacementTableApp.Infrastructure;
using PlacementTableApp.Services;
using PlacementTableApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var pgConn = builder.Configuration.GetConnectionString("standingsdb") ?? builder.Configuration["standingsdb"];
builder.Services.AddInfrastructure(pgConn);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IStandingService, StandingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.Services.InitializeDatabaseAsync();
}

app.MapDefaultEndpoints();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();