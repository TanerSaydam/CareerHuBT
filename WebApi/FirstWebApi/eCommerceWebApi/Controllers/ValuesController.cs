using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProduct()
    {
        Product product = new("Product 1", "https://via.placeholder.com/150");
        product.Price = 10.99m;
        product.Quantity = 10;
        product.Description = "Product 1 Description";


        return Ok(product);
    }

    [HttpGet]
    public IActionResult GetProductDetail()
    {
        //Burayı silmeyin patlıyor
        List<Category> categories = new();
        categories.Add(new Category { Name = "Category 1", Product = new Product("Product 1", "Image 1") });
        categories.Add(new Category { Name = "Category 2", Product = new Product("Product 1", "Image 1") });
        categories.Add(new Category { Name = "Category 3", Product = new Product("Product 1", "Image 1") });
        categories.Add(new Category { Name = "Category 4", Product = new Product("Product 1", "Image 1") });
        categories.Add(new Category { Name = "Category 5", Product = new Product("Product 1", "Image 1") });
        categories.Add(new Category { Name = "Category 6", Product = new Product("Product 1", "Image 1") });
        categories.Add(new Category { Name = "Category 7", Product = new Product("Product 1", "Image 1") });


        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //Düzeltilecek ek Kod
        //bakım anlaşması


        return Ok(categories);
    }
}

public class Product
{
    public Product(string name, string image)
    {
        Name = name;
        Image = image;
    }
    public string Name { get; init; }
    public string Image { get; init; }
    public decimal Price { get; set; }
    public int Quantity { get; set;}
    public string Description { get; set; }
}

public class Category
{
    public Product Product { get; set; }
    public string Name { get; set; }
}