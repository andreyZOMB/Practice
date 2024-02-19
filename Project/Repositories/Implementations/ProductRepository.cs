using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.DBObjects;
using Project.Entities;
using Project.Repositories.Interfaces;

namespace Project.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ProductEntity?> GetAll()
        {
            var rez = _dbContext.Products.AsNoTracking();
            return _mapper.Map<IEnumerable<ProductEntity?>>(rez);
        }

        public IEnumerable<ProductEntity?> GetByCategory(int categoryId)
        {
            var rez = _dbContext.Products.AsNoTracking().Where(product => product.CategoryId == categoryId);
            return _mapper.Map<IEnumerable<ProductEntity?>>(rez);
        }

        public ProductEntity? GetById(int id)
        {
            var rez = _dbContext.Products.AsNoTracking().SingleOrDefault(product => product.Id == id);
            return _mapper.Map<ProductEntity?>(rez);
        }

        public void Add(ProductEntity product)
        {
            var local = _mapper.Map<Product>(product);
            _dbContext.Products.Add(local);
            _dbContext.SaveChanges();
        }

        public void Change(ProductEntity product)
        {
            var local = _mapper.Map<Product>(product);
            _dbContext.Products.Update(local);
            _dbContext.SaveChanges();
        }

        public void Delete(ProductEntity product)
        {
            var local = _mapper.Map<Product>(product);
            _dbContext.Products.Remove(local);
            _dbContext.SaveChanges();
        }
    }
}
