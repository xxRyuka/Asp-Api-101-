using firstApi.DTO;
using firstApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        
        var items = Models.Repository._products.ToList();
        return items!=null ? Ok(items) : NotFound();

    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = Models.Repository._products.FirstOrDefault(x => x.Id == id);
        
        return item!=null ? Ok(item) : NotFound();
    }
    [HttpPost]
    public IActionResult AddProduct([FromBody] CreateProductDto productDTO)
    {
       Models.Repository.AppProduct(productDTO);
            
        return Ok(productDTO);
    }
}