using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantServer.Domain.Abstractions;
using RestaurantServer.Domain.Tables;
using RestaurantServer.Infrastructure.Context;
using RestaurantServer.Infrastructure.Repositories;

namespace RestaurantServer.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(cfr =>
        {
            cfr
            .UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });


        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}
