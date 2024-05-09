
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Migration.Models;

namespace Migration.Data;


public class AppDbContext : DbContext
{

    public DbSet<Course> Courses { get; set; } 
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseMySQL("Server = 127.0.0.1 ; Database = testmigration; Uid = root; Password = 1234;");


    }


    protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }



}