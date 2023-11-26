using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;

namespace RestaurantServer.BenchMark;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<BenchMarkService>();
        Console.ReadLine();
    }
}

public class BenchMarkService
{
    ApplicationDbContext context = new();

    [Benchmark(Baseline = true)]
    public async Task<List<TableDto>> ToListAsync()
    {
        List<Table> tables = await context.Tables.OrderBy(p=> p.Number).ToListAsync();
        List<TableDto> response = tables.Select(s => new TableDto()
        {
            Id = s.Id,
            Number = s.Number,
            IsAvailable = s.IsAvailable
        }).ToList();

        return response;
    }

    [Benchmark]
    public async Task<List<TableDto>> AsQueryable()
    {
        List<TableDto> response = 
            await context.Tables
            .OrderBy(p => p.Number)
            .AsQueryable()
            .Select(s => new TableDto()
        {
            Id = s.Id,
            Number = s.Number,
            IsAvailable = s.IsAvailable
        }).ToListAsync();

        return response;
    }
}

public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-3BJ5GK9\\SQLEXPRESS;Initial Catalog=RestaurantDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Table> Tables { get; set; }
}

public sealed class Table
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Amount { get; set; }
}

public sealed class TableDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public bool IsAvailable { get; set; }
}