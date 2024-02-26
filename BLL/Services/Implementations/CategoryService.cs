using BLL.Entities;
using DAL.Repositories.Interfaces;
using BLL.Services.Interfaces;
using AutoMapper;
using BLL.DTObjects.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using DAL.DBObjects;

namespace BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IActionResult> GetAllAsync()
        {
            var categoryEntity = _mapper.Map<IEnumerable<CategoryEntity>>(await _repository.GetAllAsync());
            var rez = _mapper.Map<IEnumerable<DefaultCategoryOutput>>(categoryEntity);
            return ((IConvertToActionResult)new ActionResult<IEnumerable<DefaultCategoryOutput>>(rez)).Convert();
        }

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(await _repository.GetByIdAsync(id));
            var rez = _mapper.Map<DefaultCategoryOutput>(categoryEntity);
            if (rez is not null)
            {
                return ((IConvertToActionResult)new ActionResult<DefaultCategoryOutput>(rez)).Convert();
            }
            else
            {
                return ((IConvertToActionResult)new ActionResult<string>($"No category with Id {id}")).Convert();
            }
        }
        public async Task<IActionResult> GetByNameAsync(string categoryName)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(await _repository.GetByNameAsync(categoryName));
            var rez = _mapper.Map<DefaultCategoryOutput>(categoryEntity);
            if (rez is not null)
            {
                return ((IConvertToActionResult)new ActionResult<DefaultCategoryOutput>(rez)).Convert();
            }
            else
            {
                return ((IConvertToActionResult)new ActionResult<string>($"No category with name {categoryName}")).Convert();
            }
        }

        public async Task<IActionResult> AddAsync(AddCategoryInput category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            var categoryDB = _mapper.Map<CategoryDB>(categoryEntity);
            if (await _repository.AddAsync(categoryDB))
            {
                return ((IConvertToActionResult)new ActionResult<string>("Success")).Convert();
            }
            else
            {
                return ((IConvertToActionResult)new ActionResult<string>("Failed")).Convert();
            }
        }
        public async Task<IActionResult> ChangeAsync(ChangeCategoryInput category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            var categoryDB = _mapper.Map<CategoryDB>(categoryEntity);
            var productDB = _repository.GetByIdAsync(categoryDB.Id);
            if (productDB is not null)
            {
                if (await _repository.ChangeAsync(categoryDB))
                {
                    return ((IConvertToActionResult)new ActionResult<string>("Success")).Convert();
                }
            }
            return ((IConvertToActionResult)new ActionResult<string>("Failed")).Convert();
        }

        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var categoryDB = await _repository.GetByIdAsync(id);
            if (categoryDB is not null)
            {
                if (await _repository.DeleteAsync(categoryDB))
                {
                    return ((IConvertToActionResult)new ActionResult<string>("Success")).Convert();
                }
            }
            return ((IConvertToActionResult)new ActionResult<string>("Failed")).Convert();
        }

    }
}
