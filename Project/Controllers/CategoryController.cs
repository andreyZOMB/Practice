using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project.Entities;
using Project.DTObjects.Category;
using Project.Services.Interfaces;


namespace Project.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{

    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet()]
    public IEnumerable<DefaultCategoryOutput> GetAll()
    {
        return _mapper.Map<IEnumerable<DefaultCategoryOutput>>(_service.GetAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DefaultCategoryOutput> GetById(int id)
    {
        var rez = _service.GetById(id);
        if (rez is null)
        {
            return NotFound($"No category with Id {id}");
        }
        return _mapper.Map<DefaultCategoryOutput>(rez);
    }

    [HttpGet("getByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<DefaultCategoryOutput> GetByName(String categoryName)
    {
        var rez = _service.GetByName(categoryName);
        if (rez is null)
        {
            return Ok($"No category with name {categoryName}");
        }
        return new ActionResult<DefaultCategoryOutput>(_mapper.Map<DefaultCategoryOutput>(rez));
    }

    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> Add(AddCategoryInput product)
    {
        var local = _mapper.Map<CategoryEntity>(product);
        _service.Add(local);
        return Ok();
    }

    [HttpPost("change")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult Change(ChangeCategoryInput product)
    {
        var local = _mapper.Map<CategoryEntity>(product);
        if (_service.Change(local))
        {
            return Ok("Success");
        }
        return Ok("Category not found");
    }

    [HttpGet("deleteById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult DeleteById(int id)
    {
        _service.DeleteById(id);
        return Ok();
    }
}
