using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project.Entities;
using Project.DTObjects.Product;
using Project.Services.Interfaces;


namespace Project.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public ProductsController(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet()]
    public IEnumerable<DefaultProductOutput> GetAll()
    {
        return _mapper.Map<IEnumerable<DefaultProductOutput>>(_service.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DefaultProductOutput> GetById(int id)
    {
        var rez = _service.GetById(id);
        if (rez is null)
        {
            return NotFound($"No product with Id {id}");
        }
        return _mapper.Map<DefaultProductOutput>(rez);
    }

    [HttpGet("getByCategory")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<DefaultProductOutput>> GetByCategory(int categoryId)
    {
        var rez = _service.GetByCategory(categoryId);
        if (rez is null)
        {
            return NotFound($"No products in category {categoryId}");
        }
        return new ActionResult<IEnumerable<DefaultProductOutput>>(_mapper.Map<IEnumerable<DefaultProductOutput>>(rez));
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Add(AddProductInput product)
    {
        var local = _mapper.Map<ProductEntity>(product);
        if (_service.Add(local))
        {
            return Ok();
        }
        return Ok("Category not found");
    }

    [HttpPost("change")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Change(ChangeProductInput product)
    {
        var local = _mapper.Map<ProductEntity>(product);
        if (_service.Change(local))
        {
            return Ok("Success");
        }
        return Ok("Product or category not found");
    }

    [HttpGet("deleteById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult DeleteById(int id)
    {
        _service.DeleteById(id);
        return Ok();
    }
}
