using FirstApp.Models.Enitities;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Cart> Carts { get; set; }
    
    public DbSet<Item> Items { get; set; }
}