using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DAL;


namespace API
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private IConfigurationRoot? Configuration { get; set; }
        public ApplicationContext CreateDbContext(string[] args)
        {

            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("PracticeDB"));

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
