using DAL.DBObjects;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationContext _dbContext;

        public ProductRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductDB?>> GetAllAsync()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ProductDB?>> GetByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products.AsNoTracking().Where(product => product.CategoryId == categoryId).ToListAsync();
        }

        public async Task<ProductDB?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking().SingleOrDefaultAsync(product => product.Id == id);
        }

        public async Task<bool> AddAsync(ProductDB product)
        {
            _dbContext.Products.Add(product);
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

        public async Task<bool> ChangeAsync(ProductDB product)
        {
            _dbContext.Products.Update(product);
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

        public async Task<bool> DeleteAsync(ProductDB product)
        {
            _dbContext.Products.Remove(product);
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
