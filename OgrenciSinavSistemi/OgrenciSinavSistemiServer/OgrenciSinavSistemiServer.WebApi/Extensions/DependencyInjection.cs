using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.Context;
using OgrenciSinavSistemiServer.WebApi.Models.Exams;
using OgrenciSinavSistemiServer.WebApi.Models.Users;
using OgrenciSinavSistemiServer.WebApi.Options;
using OgrenciSinavSistemiServer.WebApi.Services.Jwts;
using Scrutor;
using System.Reflection;
using System.Text;

namespace OgrenciSinavSistemiServer.WebApi.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(
        this IServiceCollection services)
    {
        //services
        //    .Scan(action => action
        //    .FromAssemblies(Assembly.GetExecutingAssembly())
        //    .AddClasses(publicOnly: false)
        //    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        //    .AsMatchingInterface()
        //    .WithScopedLifetime()
        //);
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IStudenService, StudentService>();

        return services;
    }

    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        return services;
    }

    public static IServiceCollection AddAuthenticationDI(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<Jwt>(configuration.GetSection("Jwt"));

        services.AddAuthentication().AddJwtBearer(options =>
        {
            var secretKey = configuration.GetSection("Jwt:SecretKey").Value;
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                    secretKey ?? ""))
            };
        });

        return services;
    }
}
