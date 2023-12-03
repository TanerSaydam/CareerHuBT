namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Product product = new() { Id =1, Name = "Domates", CategoryId = 1 };

        Product product1 = (Product)product.Clone();

        product1.CategoryId = 2;
    }
}

public class Product : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual int CategoryId { get; set; }

    public object Clone()
    {
        return new Product
        {
            Id = this.Id,
            Name = this.Name,
            CategoryId = this.CategoryId
        };
    }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set;}
}
