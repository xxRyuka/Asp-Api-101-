using firstApi.DTO;
using firstApi.Models;

namespace firstApi.Mappers;

public interface IProductMapper
{
    Product CreateDtoToProduct(CreateProductDto dto);
    ProductDto ProductToProductDto(Product product);
    
    List<ProductDto> ProductToProductDto(List<Product> product);

}