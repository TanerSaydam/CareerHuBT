using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Context;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}

public class A: D
{
    public string Name { get; set; }
}

public interface C
{
    string Address { get; set; }
}

public class D : B
{
    public int Number { get; set; }
}

public class B : C
{
    public int Age { get; set; }
    public string Address { get; set ; }
}
