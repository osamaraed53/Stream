using Microsoft.EntityFrameworkCore;
using Stream.Models;
using static System.Collections.Specialized.BitVector32;

namespace Stream.Data;



public class AppDbContext(DbContextOptions options) : DbContext(options)
{


    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

    }


    protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }



}

