using DAL.DBObjects;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationContext _dbContext;

        public CategoryRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryDB?>> GetAllAsync()
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }


        public async Task<CategoryDB?> GetByNameAsync(string name)
        {
            return await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(category => category.Name == name);
        }

        public async Task<CategoryDB?> GetByIdAsync(int id)
        { 
            return await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(category => category.Id == id);
        }

        public async Task<bool> AddAsync(CategoryDB category)
        {
            _dbContext.Categories.Add(category);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> ChangeAsync(CategoryDB category)
        {
            _dbContext.Categories.Update(category);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(CategoryDB category)
        {
            _dbContext.Categories.Remove(category);
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}
