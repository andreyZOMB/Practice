using BLL.DTObjects.Product;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IActionResult> GetAll();
        public Task<IActionResult> GetById(int id);
        public Task<IActionResult> GetByCategory(int categoryId);
        public Task<IActionResult> Add(AddProductInput product);
        public Task<IActionResult> Change(ChangeProductInput product);
        public Task<IActionResult> DeleteById(int id);
    }
}
