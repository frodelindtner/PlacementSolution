using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PlacementTableApp.Infrastructure;
using PlacementTableApp.Services;
using PlacementTableApp.Services.Interfaces;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);
Batteries_V2.Init();

builder.AddServiceDefaults();

var pgConn = builder.Configuration.GetConnectionString("standingsdb") ?? builder.Configuration["standingsdb"];
builder.Services.AddDbContext<StandingDbContext>(options => options.UseNpgsql(pgConn));

builder.Services.AddInfrastructure();

// Add services to the container.
builder.Services.AddControllersWithViews();

// allow resolving DbContext (base type) by returning the StandingContext
builder.Services.AddScoped<DbContext>(sp => sp.GetRequiredService<StandingDbContext>());

// Register generic repository and TeamService for DI
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IStandingService, StandingService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.Services.InitializeDatabaseAsync();
}

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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


