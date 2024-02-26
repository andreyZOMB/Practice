using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using BLL.DTObjects.Product;


namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        return await _service.GetAll();
    }

    [HttpGet("getById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return await _service.GetById(id);
    }

    [HttpGet("getByCategory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByCategoryAsync(int categoryId)
    {
        return await _service.GetByCategory(categoryId);
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAsync(AddProductInput product)
    {
        return await _service.Add(product);
    }

    [HttpPost("change")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ChangeAsync(ChangeProductInput product)
    {
        return await _service.Change(product);
    }

    [HttpGet("deleteById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteByIdAsync(int id)
    {
        return await _service.DeleteById(id);
    }
}
