using Microsoft.EntityFrameworkCore;

using System;

using WhatTheTea.MarketApp.Models;

namespace WhatTheTea.MarketApp.Data;

public class MarketContext : DbContext
{
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Product> Products { get; set; }

    public string DbPath { get; }

    public MarketContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
