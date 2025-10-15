using FirstApp.Models.Enitities;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}