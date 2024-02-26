using DAL.DBObjects;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDB?>> GetAllAsync();
        public Task<IEnumerable<ProductDB?>> GetByCategoryAsync(int categoryId);
        public Task<ProductDB?> GetByIdAsync(int id);
        public Task<bool> AddAsync(ProductDB product);
        public Task<bool> ChangeAsync(ProductDB product);
        public Task<bool> DeleteAsync(ProductDB product);
    }
}
