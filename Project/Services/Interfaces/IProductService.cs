using Project.Entities;

namespace Project.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<ProductEntity?> GetAll();
        public ProductEntity? GetById(int id);
        public IEnumerable<ProductEntity?> GetByCategory(int categoryId);
        public bool Add(ProductEntity product);
        public bool Change(ProductEntity product);
        public void DeleteById(int id);
    }
}
