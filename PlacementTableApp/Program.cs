using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using PlacementTableApp.Storage.Repositories;
using PlacementTableApp.Storage;
using PlacementTableApp.Services;
using PlacementTableApp.Services.Interfaces;
using PlacementTableApp.Repositories.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Initialize SQLite provider from SQLitePCLRaw bundle before any EF Core/DbContext use
// Requires package SQLitePCLRaw.bundle_e_sqlite3
Batteries_V2.Init();

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<StandingContext>(options =>
    options.UseSqlite(@"Data Source=C:\Users\frode\AppData\Local\standingdb.db"));

// allow resolving DbContext (base type) by returning the StandingContext
builder.Services.AddScoped<DbContext>(sp => sp.GetRequiredService<StandingContext>());



// Register generic repository and TeamService for DI
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IStandingUSService, StandingUSService>();

var app = builder.Build();

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


