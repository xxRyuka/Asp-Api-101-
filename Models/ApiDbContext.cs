using Microsoft.EntityFrameworkCore;

namespace firstApi.Models;

public class ApiDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // Mantigini anla aslında many to many yok 2 tane one to many kullanıyoruz burda ara tablo kullanarak bağlantı kuruyoruz 
        // Many to Many Product - Category 
        modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.CategoryId, pc.ProductId }); // Key tanımlamaları 
        
        modelBuilder.Entity<ProductCategory>()
             .HasOne(pc => pc.Category)
             .WithMany(c => c.ProductCategories)
             .HasForeignKey(pc => pc.CategoryId);
        
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);
    }
}