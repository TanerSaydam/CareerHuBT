using Application.Service;
using DependencyInjection.Context;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly Product _product;  
    private readonly AppDbContext _context;
    private readonly IBookService _bookService;
    private readonly IProductService _productService;
    public ValuesController(Product product, AppDbContext context, IProductService productService, IBookService bookService)
    {
        _product = product;
        _context = context;
        _productService = productService;
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult Save()
    {
       
        //Product product = new(); //instance türetme

        _product.Name = "Kalem";

        //var optionsBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=DESKTOP-3BJ5GK9\\SQLEXPRESS;Initial Catalog=BookStoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //AppDbContext context = new(options: optionsBuilder.Options);

        _productService.Save();
        _bookService.Save();

        return Ok(_product);
    }
}

public class Product
{    
   
    public Product()
    {
        
    }
    public string Name { get; set; }
}