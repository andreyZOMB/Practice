using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Entities;
using System.Collections.Generic;
using System.Text.Json;

namespace Project.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController: ControllerBase
{

    private readonly ApplicationContext _dbContext;

    public ProductsController(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet()]
    public IEnumerable<Product> Get()
    {
            return _dbContext.Products.Include(product => product.Category);     
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> GetById(int id)
    {
        var product = _dbContext.Products.Include(product => product.Category).SingleOrDefault(product => product.Id == id);
        if (product is null)
        {
            return NotFound($"No product with Id {id}");
        }
        return product;
    }
}
