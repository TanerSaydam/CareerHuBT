using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Context;

public sealed class ApplicationDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=TANER\\SQLEXPRESS;Initial Catalog=TodoDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<TodoModel> Todos { get; set; }
}

public sealed class TodoModel
{
    public int Id { get; set; }
    public string Work { get; set; }
}
