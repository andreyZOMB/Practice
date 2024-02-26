using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;

namespace API
   
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            return serviceCollection;
        }
    }
}
