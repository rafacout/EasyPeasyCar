using EasyPeasy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyPeasy.Infrastructure.Context;

public class EasyPeasyDbContext : DbContext
{
    public EasyPeasyDbContext()
    {
    }

    public EasyPeasyDbContext(DbContextOptions<EasyPeasyDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EasyPeasyDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Rent> Rents { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
}
