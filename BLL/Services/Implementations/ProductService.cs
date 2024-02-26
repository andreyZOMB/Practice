using AutoMapper;
using BLL.DTObjects.Product;
using BLL.Entities;
using BLL.Services.Interfaces;
using DAL.DBObjects;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BLL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> GetAll()
        {
            var productEntity = _mapper.Map<IEnumerable<ProductEntity>>(await _productRepository.GetAllAsync());
            var rez = _mapper.Map<IEnumerable<DefaultProductOutput>>(productEntity);
            return ((IConvertToActionResult)new ActionResult<IEnumerable<DefaultProductOutput>>(rez)).Convert();
        }

        public async Task<IActionResult> GetById(int id)
        {
            var productEntity = _mapper.Map<ProductEntity>(await _productRepository.GetByIdAsync(id));
            var rez = _mapper.Map<DefaultProductOutput>(productEntity);
            return ((IConvertToActionResult)new ActionResult<DefaultProductOutput>(rez)).Convert();
        }
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var productEntity = _mapper.Map<IEnumerable<ProductEntity>>(await _productRepository.GetByCategoryAsync(categoryId));
            var rez = _mapper.Map<IEnumerable<DefaultProductOutput>>(productEntity);
            return ((IConvertToActionResult)new ActionResult<IEnumerable<DefaultProductOutput>>(rez)).Convert();
        }

        public async Task<IActionResult> Add(AddProductInput product)
        {
            var lproductEntity = _mapper.Map<ProductEntity>(product);
            var productDB = _mapper.Map<ProductDB>(lproductEntity);
            var categoryDB = _categoryRepository.GetByIdAsync(productDB.CategoryId);
            if (categoryDB is not null)
            {
                if (await _productRepository.AddAsync(productDB))
                {
                    return ((IConvertToActionResult)new ActionResult<string>("Success")).Convert();
                }
                return ((IConvertToActionResult)new ActionResult<string>("Category not found")).Convert();
            }
            return ((IConvertToActionResult)new ActionResult<string>("Failed")).Convert();
        }
        public async Task<IActionResult> Change(ChangeProductInput product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            var productDB = _mapper.Map<ProductDB>(productEntity);
            var localProduct = _productRepository.GetByIdAsync(productDB.Id);
            if (localProduct is not null)
            {
                var localCategory = _categoryRepository.GetByIdAsync(productDB.CategoryId);
                if (localCategory is not null)
                {
                    if (await _productRepository.ChangeAsync(productDB))
                    {
                        return ((IConvertToActionResult)new ActionResult<string>("Success")).Convert();
                    }
                    return ((IConvertToActionResult)new ActionResult<string>("Failed")).Convert();
                }
                return ((IConvertToActionResult)new ActionResult<string>("Category not found")).Convert();
            }
            return ((IConvertToActionResult)new ActionResult<string>("Product not found")).Convert();
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product is not null)
            {
                if (await _productRepository.DeleteAsync(product))
                {
                    return ((IConvertToActionResult)new ActionResult<string>("Success")).Convert();
                }
                return ((IConvertToActionResult)new ActionResult<string>("Failed")).Convert();
            }
            return ((IConvertToActionResult)new ActionResult<string>("Product not found")).Convert();

        }

    }
}
