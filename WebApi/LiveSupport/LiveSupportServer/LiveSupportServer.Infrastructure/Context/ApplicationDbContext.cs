using LiveSupportServer.Domain.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LiveSupportServer.Infrastructure.Context;

internal sealed class ApplicationDbContext(IConfiguration configuration) : DbContext, IUnitOfWork
{    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}