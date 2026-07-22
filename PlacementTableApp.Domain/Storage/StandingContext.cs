using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using PlacementTableApp.Repositories.Models;

public class StandingContext : DbContext
{
    public DbSet<ResultEnty> Result { get; set; }
    public DbSet<TeamEnty> Team { get; set; }

    public string DbPath { get; }

    public StandingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "StandingDB.db");
    }

    // Constructor used by DI when configuring DbContextOptions
    public StandingContext(DbContextOptions<StandingContext> options)
        : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "StandingDB.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source= {DbPath}");
}
