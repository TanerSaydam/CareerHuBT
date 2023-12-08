using Microsoft.EntityFrameworkCore;
using ODataAndElasticSearchWebApi.Models;

namespace ODataAndElasticSearchWebApi.Context;

public sealed class ApplicationDbContext : DbContext
{    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-3BJ5GK9\\SQLEXPRESS;Initial Catalog=ODataAndElasticSearchDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<User> Users { get; set; }
}
