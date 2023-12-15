using Microsoft.EntityFrameworkCore;

namespace LiveSupportServer.ExampleConsoleApp;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public static void CreateProduct(string name, int stock)
    {
        //volkan abinin kodları
        ApplicationDbContext context = new();

        if (context.Products.Any(p => p.Name == name))
        {
            throw new ArgumentException("Bu ürün adına ait daha önce kayıt oluşturulmuş!");
        }

        Product product = new(0, name, stock);

        context.Products.Add(product);
        context.SaveChanges();
    }

    public static void UpdateProduct(int id, string name, int stock)
    {
        ApplicationDbContext context = new();
        Product? product = context.Products.Find(id);
        if (product is null) throw new ArgumentException("Ürün bulunamadı!");

        product.Update(name, stock);

        context.SaveChanges();
    }
}

public class Product
{
    public Product(int ıd, string name, int stock)
    {
        Id = ıd;
        Name = name;
        Stock = stock;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Stock { get; private set; }

    public void Update(string name, int stock)
    {
        Name = name;
        Stock = stock;
    }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}