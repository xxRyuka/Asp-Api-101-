using firstApi.DTO;
using firstApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult GelAllProducts()
    {
        var items2 = Models.Repository._products.Select(p => new ListViewDto
        {
            Id = p.Id,
            Price = p.Price,
            Name = p.Name+" dto",
            Stock = p.Stock
            
        }).ToList();
        
        //view dto yapalim simdilik controllerda olsun zaten bir mimariye bindireceğiz 
        var items = Models.Repository._products.ToList();
        
        
        return items!=null ? Ok(items2) : NotFound();

    }

    [HttpGet("search")]
    public IActionResult GelAllProductsByQuery([FromQuery] string query)
    {
        var list = Models.Repository._products.Where(p => p.Name.ToUpper().Contains(query.ToUpper())).ToList();
        
        return list != null ? Ok(list) : NotFound();
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
       Models.Repository.AppProduct(productDTO);
            
        return Ok(productDTO +" " +productDTO.Name + " has been added");
    }


    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id,[FromBody] UpdateProductDto updateProductDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // gelen veriyi test ettik once 
        }
        
        var item = Models.Repository._products.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return BadRequest("Invalid id item is null");
        }
        item.Name = updateProductDto.Name;
        item.Price = updateProductDto.Price;
        item.Stock = updateProductDto.Stock;
        return Ok($"ürün {id} güncellendi");
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        
        var item = Models.Repository._products.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return BadRequest("Invalid id item is null");
        }
        Models.Repository._products.Remove(item);
        return Ok(item.Name + " has been deleted");
    }
}