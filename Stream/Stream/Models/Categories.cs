namespace Stream.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string? CategoryDescription { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();

}
