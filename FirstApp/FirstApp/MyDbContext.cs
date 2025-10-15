using Microsoft.EntityFrameworkCore;

namespace FirstApp;

public class MyDbContext(DbContextOptions<MyDbContext> options): DbContext(options)
{
    public DbSet<MyDbContext> Contexts { get; set; }
}