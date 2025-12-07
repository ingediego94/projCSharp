using Microsoft.EntityFrameworkCore;
using projCSharp.Domain;

namespace projCSharp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = modelBuilder.Entity<User>();
        user.HasIndex(u => u.Email)
            .IsUnique();
        user.HasIndex(u => u.NumDoc)
            .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Categorie> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}