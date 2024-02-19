using Microsoft.EntityFrameworkCore;
using Project.DBObjects;
using Project.Entities;
using Project.Repositories.Interfaces;
using Project.Services.Interfaces;

namespace Project.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }


        public IEnumerable<ProductEntity?> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ProductEntity? GetById(int id)
        {
            return _productRepository.GetById(id);
        }
        public IEnumerable<ProductEntity?> GetByCategory(int categoryId)
        {
            return _productRepository.GetByCategory(categoryId);
        }

        public bool Add(ProductEntity product)
        {
            var localCategory = _categoryRepository.GetById(product.CategoryId);
            if (localCategory is not null)
            {
                _productRepository.Add(product);
                return true;
            }
            return false;
        }
        public bool Change(ProductEntity product)
        {
            var localProduct = _productRepository.GetById(product.Id);
            if (localProduct is not null)
            {
                var localCategory = _categoryRepository.GetById(product.CategoryId);
                if (localCategory is not null)
                {
                    _productRepository.Change(product);
                    return true;
                }
            }
            return false;
        }

        public void DeleteById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product is not null)
            {
                _productRepository.Delete(product);
            }
        }

    }
}
