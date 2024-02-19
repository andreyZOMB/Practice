using Project.Entities;

namespace Project.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<ProductEntity?> GetAll();
        public IEnumerable<ProductEntity?> GetByCategory(int categoryId);
        public ProductEntity? GetById(int id);
        public void Add(ProductEntity product);
        public void Change(ProductEntity product);
        public void Delete(ProductEntity product);
    }
}
