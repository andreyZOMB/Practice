using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DAL;


namespace DAL
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.GetFullPath("../API/appsettings.json"))
                .Build();

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(configuration.GetConnectionString("PracticeDB"))
                .Options;

            return new ApplicationContext(options);
        }
    }
}
