using firstApi.DTO;
using firstApi.Mappers;
using firstApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductEfController : ControllerBase
{
    private readonly IProductMapper _productMapper;
    private readonly ApiDbContext _context;

    public ProductEfController(ApiDbContext context, IProductMapper productMapper)
    {
        _context = context;
        _productMapper = productMapper;
    }


    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto dto)
    {
        var servicedProduct = _productMapper.CreateDtoToProduct(dto);

        _context.Products.Add(servicedProduct);
        _context.SaveChanges();

        var savedProduct = _context.Products
            .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefault(p => p.Id == servicedProduct.Id);

        ProductDto returnDto = new ProductDto()
        {
            Id = savedProduct.Id,
            Name = savedProduct.Name,
            Price = savedProduct.Price,
            Stock = savedProduct.Stock,
            CategoryIds = savedProduct.ProductCategories.Select(pc => new CategoryDTO()
            {
                Id = pc.CategoryId,
                Name = pc.Category.Name
            }).ToList()
        };
        return Ok(returnDto);
    }


    [HttpGet] // Harika Calisiyor Simdilik Yüzeysel olarak yaptim katmanlara ayrılacak mapperlar yazılacak (manuel yazmayi düşünüyorum)
    public IActionResult Index()
    {
        var products = _context.Products
            .Include(p => p.ProductCategories)
               .ThenInclude(pc => pc.Category)
            .ToList();

        // var result = products.Select(p => new ProductDto
        // {
        //     Id = p.Id,
        //     Name = p.Name,
        //     Price = p.Price,
        //     Stock = p.Stock,
        //     CategoryIds = p.ProductCategories.Select(pc => new CategoryDTO()
        //     {
        //         Id = pc.CategoryId,
        //         Name = pc.Category.Name
        //     }).ToList()
        // });


        var servicedDTO = _productMapper.ProductToProductDto(products);
        return Ok(servicedDTO);
    }
}