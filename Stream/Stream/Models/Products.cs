namespace Stream.Models;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public string Color { get; set; } 
    public string Size { get; set; }
    public int CategoryId{ get; set; }
    public decimal Price { get; set; } = 0;
    public int Qty { get; set; } = 0;

    public Category Category { get; set; }
}
