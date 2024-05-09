using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Stream.Data;
using Stream.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stream.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReadFileController(IConfiguration config, AppDbContext context) : ControllerBase
{

    protected readonly IConfiguration _config = config;
    protected readonly AppDbContext _context = context;


    // POST api/<ValuesController>
    [HttpPost]
    public async Task<IActionResult> ReadFile([FromForm] IFormFile file)
    {
        var categoriesSet = new HashSet<string>();
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using var stream = file.OpenReadStream();
            using var excelPackage = new ExcelPackage(stream);
            var sheet = excelPackage.Workbook.Worksheets[0];

            for (int row = 2; row <= sheet.Dimension.End.Row; row++)
            {
                categoriesSet.Add(sheet.Cells[row, 5].Value?.ToString()?.ToLower()?.Trim());
            }
            categoriesSet.Remove(null);

            var categories = new Dictionary<string, Category>();
            if (categoriesSet.Count > 0)
            {
                foreach (var category in categoriesSet)
                {
                    var newCategory = new Category { CategoryName = category };
                    categories[category] = newCategory;
                }
                _context.Categories.AddRange(categories.Values);
                await _context.SaveChangesAsync();
            }


            for (int row = 2; row <= sheet.Dimension.End.Row; row++)
            {
                var productName = sheet.Cells[row, 1].Value?.ToString()?.ToLower()?.Trim();
                var productDescription = (sheet.Cells[row, 2].Value?.ToString()?.ToLower());
                var color = (sheet.Cells[row, 3].Value?.ToString()?.ToLower()?.Trim());
                var size = (sheet.Cells[row, 4].Value?.ToString()?.ToLower()?.Trim());
                string categoryName = sheet.Cells[row, 5].Value?.ToString()?.ToLower()?.Trim() ?? "";
                var price = Convert.ToDecimal(sheet.Cells[row, 6].Value);
                var qty = Convert.ToInt32(sheet.Cells[row, 7].Value);


                var categoryId = categories.TryGetValue(categoryName , out var value) ? value.CategoryId : 1;

                if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(color) || string.IsNullOrEmpty(size) || qty == null)
                {
                    Console.WriteLine($"Missing required data in {row}");
                }
                var product = new Product
                {
                    ProductName = productName ?? $"in Row :{row}",
                    ProductDescription = productDescription,
                    Color = color ?? "empty",
                    Size = size ?? "empty",
                    CategoryId = categoryId,
                    Price = price,
                    Qty = qty,
                };
                _context.Products.Add(product);
                _context.SaveChanges();
            }


            return Ok("Products imported successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }



}
