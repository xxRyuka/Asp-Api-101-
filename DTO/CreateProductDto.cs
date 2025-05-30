namespace firstApi.DTO;

public class CreateProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public ICollection<int> CategoryIds { get; set; } = new List<int>();

}