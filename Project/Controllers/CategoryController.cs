using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTObjects.Category;


namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{

    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("getById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return await _service.GetByIdAsync(id);
    }

    [HttpGet("getByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByNameAsync(String categoryName)
    {
        return await _service.GetByNameAsync(categoryName);
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAsync(AddCategoryInput category)
    {
        return await _service.AddAsync(category);
    }

    [HttpPost("change")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangeAsync(ChangeCategoryInput category)
    {
        return await _service.ChangeAsync(category);
    }

    [HttpGet("deleteById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        return await _service.DeleteByIdAsync(id);
    }
}
