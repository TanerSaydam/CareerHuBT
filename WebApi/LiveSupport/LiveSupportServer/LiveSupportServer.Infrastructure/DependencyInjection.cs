using LiveSupportServer.Application.Abstractions;
using LiveSupportServer.Application.Abstracts;
using LiveSupportServer.Domain.Abstracts;
using LiveSupportServer.Domain.ChatRooms;
using LiveSupportServer.Domain.Users;
using LiveSupportServer.Infrastructure.Authentication;
using LiveSupportServer.Infrastructure.Context;
using LiveSupportServer.Infrastructure.Hubs;
using LiveSupportServer.Infrastructure.Options;
using LiveSupportServer.Infrastructure.Repositories;
using LiveSupportServer.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LiveSupportServer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrasturcture(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSignalR();

        services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ISignalRService, SignalRService>();

        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<IUnitOfWork>(cfr => cfr.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IJwtProvider, JwtProvider>();
        services.Configure<Jwt>(configuration.GetSection("Jwt"));

        var secretKey = configuration.GetSection("Jwt:SecretKey").Value;
        services.AddAuthentication().AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey ?? ""))
            };
        });
        return services;
    }
}