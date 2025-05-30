using System.Drawing;

namespace firstApi.Models;


// Realtionsalr Yapilcak 
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }

    public ICollection<ProductCategory> ProductCategories { get; set; } = new  List<ProductCategory>();
}