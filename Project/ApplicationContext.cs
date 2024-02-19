namespace Project;
using Microsoft.EntityFrameworkCore;
using Project.DBObjects;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public ApplicationContext() => Database.EnsureCreated();
}