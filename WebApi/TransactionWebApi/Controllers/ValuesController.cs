using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TransactionWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private ApplicationDbContext context = new();

    [HttpGet]
    public IActionResult Pay()
    {
        //Para çekildi onayı

        decimal total = 0;
        List<ShoppingCart> shoppingCarts = context.ShoppingCarts.Include(p=> p.Product).ToList();

        try
        {
            context.Database.BeginTransaction();
            //Product'dan Adet bilgisini düşecek
            foreach (var p in shoppingCarts)
            {
                Product product = context.Products.Find(p.ProductId);
                product.Stock--;

               context.SaveChanges();
            }

            // Sepetteki Ürünleri Siparişe aktarak
            string orderNumber = "S00000001";
            foreach (var item in shoppingCarts)
            {
                Order order = new()
                {
                    ProductId = item.ProductId,
                    OrderNumber = orderNumber,
                    Price = item.Product.Price,
                };

                total += order.Price;

                context.Add(order);
                context.SaveChanges();
            }            

            // Sepeti Temizleyecek
            context.ShoppingCarts.RemoveRange(shoppingCarts);
            context.SaveChanges();

            // Ödeme Bilgisini Kaydedecek
            Payment payment = new()
            {
                CartNumber = "123456798",
                OrderNumber = orderNumber,
                Total = total
            };

            context.Add(payment);
            context.SaveChanges();

            context.Database.CommitTransaction();

        }
        catch (Exception)
        {
            context.Database.RollbackTransaction();
            throw;
        }
        

        


        

        return NoContent();
    }
}


public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=TANER\\SQLEXPRESS;Initial Catalog=TransactionDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seed Data
        List<Product> products = new();
        for (int i = 0; i < 10; i++)
        {
            var faker = new Faker();

            Product product = new()
            {
                Id = i + 1,
                Name = faker.Vehicle.Model(),
                Price = faker.Random.Decimal(1000, 500000),
                Stock = faker.Random.Int(1, 200)
            };

            products.Add(product);
        }
        modelBuilder.Entity<Product>().HasData(products);


        List<ShoppingCart> shoppingCarts = new();
        ShoppingCart shoppingCart1 = new()
        {
            Id = 1,
            ProductId = 1
        };

        ShoppingCart shoppingCart2 = new()
        {
            Id = 2,
            ProductId = 2
        };

        ShoppingCart shoppingCart3 = new()
        {
            Id = 3,
            ProductId = 3
        };

        shoppingCarts.Add(shoppingCart1);
        shoppingCarts.Add(shoppingCart2);
        shoppingCarts.Add(shoppingCart3);

        modelBuilder.Entity<ShoppingCart>().HasData(shoppingCarts);
    }
}


public sealed class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
}

public sealed class ShoppingCart
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}

public sealed class Order
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
}

public sealed class Payment
{
    public int Id { get; set; }
    public string OrderNumber { get; set; }
    public string CartNumber { get; set; }
    public decimal Total { get; set; }
}