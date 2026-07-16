using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class BloggingContext : DbContext
{
    public DbSet<Result> Result { get; set; }
    public DbSet<Team> Team { get; set; }

    public string DbPath { get; }

    public BloggingContext()
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

public class Result
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }

}

public class Team
{
    public int Id { get; set; }
    public string Season { get; set; }
    public string City { get; set; }
    public string Name { get; set; }
    public string Division { get; set; }
    public string League { get; set; }

}