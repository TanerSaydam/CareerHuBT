using Microsoft.EntityFrameworkCore;

namespace WebApi.Context;

public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-3BJ5GK9\\SQLEXPRESS;Initial Catalog=RahatTaskDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<ApiRecord> ApiRecords { get; set; }
}

public class ApiRecord
{
    public int Id { get; set; }
    public string DataField1 { get; set; }
    public string DataField2 { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}
