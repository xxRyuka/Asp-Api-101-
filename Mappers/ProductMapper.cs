using firstApi.DTO;
using firstApi.Models;

namespace firstApi.Mappers;

public class ProductMapper : IProductMapper
{
    public Product CreateDtoToProduct(CreateProductDto dto)
    {
        Product entity = new Product()
        {
            Price = dto.Price,
            Name = dto.Name,
            Stock = dto.Stock,
            
            ProductCategories = dto.CategoryIds.Select(cid => new ProductCategory()
            {
                CategoryId = cid,
                
            }).ToList()
        };
        
        return entity;
    }

    public ProductDto ProductToProductDto(Product product)
    {
        throw new NotImplementedException();
    }

    public List<ProductDto> ProductToProductDto(List<Product> products)
    {
       var pr =  products.Select(p => new ProductDto()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            CategoryIds = p.ProductCategories.Select(pc => new CategoryDTO()
            {
                Id = pc.CategoryId,
                Name = pc.Category?.Name
            }).ToList()
        }).ToList();
       
       return pr;
    }
}