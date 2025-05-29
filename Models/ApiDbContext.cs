using Microsoft.EntityFrameworkCore;

namespace firstApi.Models;

public class ApiDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }
}