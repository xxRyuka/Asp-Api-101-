using firstApi.DTO;

namespace firstApi.Models;

public static class Repository
{
    public static List<Product> _products { get; }

    static Repository()
    {
        _products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Ahmet",
                Price = 100,
                Stock = 21
            },
            new Product()
            {
                Id = 2,
                Name = "samet",
                Price = 200,
                Stock = 11
            }
        };
    }


    public static void AppProduct(CreateProductDto dto)
    {
        Product newProduct = new()
        {
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock
        };
        newProduct.Id = _products.Count + 1;
        _products.Add(newProduct);
    }

    public static void returnDTO()
    {
        
    }
}