namespace Project;
using Microsoft.EntityFrameworkCore;
using Project.Entities;

public class ApplicationContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=Practice;Trusted_Connection=True;TrustServerCertificate=True");
    }
}