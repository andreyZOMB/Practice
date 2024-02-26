using BLL.DTObjects.Category;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IActionResult> GetAllAsync();
        public Task<IActionResult> GetByIdAsync(int id);
        public Task<IActionResult> GetByNameAsync(string Name);
        public Task<IActionResult> AddAsync(AddCategoryInput category);
        public Task<IActionResult> ChangeAsync(ChangeCategoryInput category);
        public Task<IActionResult> DeleteByIdAsync(int id);
    }
}
