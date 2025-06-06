namespace firstApi.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }


    public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}