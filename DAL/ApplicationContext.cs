using DAL.DBObjects;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<ProductDB> Products => Set<ProductDB>();
    public DbSet<CategoryDB> Categories => Set<CategoryDB>();
    public ApplicationContext() => Database.EnsureCreated();
}