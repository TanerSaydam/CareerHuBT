using LiveSupportServer.Domain.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LiveSupportServer.Infrastructure.Context;

internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=LiveSupportDb;")
        .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}