using DAL.DBObjects;

namespace DAL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryDB?>> GetAllAsync();
        public Task<CategoryDB?> GetByNameAsync(string name);
        public Task<CategoryDB?> GetByIdAsync(int id);
        public Task<bool> AddAsync(CategoryDB category);
        public Task<bool> ChangeAsync(CategoryDB category);
        public Task<bool> DeleteAsync(CategoryDB category);
    }
}
