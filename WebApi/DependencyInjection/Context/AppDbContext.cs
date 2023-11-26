using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
