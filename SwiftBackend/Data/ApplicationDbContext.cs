using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SwiftBackend.Data;

public class ApplicationDbContext : DbContext
{
    private string DbPath { get; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "SwiftOnline.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlite($"Data Source={DbPath}");
    }

    public DbSet<Camera> Cameras => Set<Camera>();
    public DbSet<Filter> Filters => Set<Filter>();
    public DbSet<Lense> Lenses => Set<Lense>();
    public DbSet<Macro> Macro => Set<Macro>();
    public DbSet<Zoom> Zoom => Set<Zoom>();
}
